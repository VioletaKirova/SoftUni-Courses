namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat 
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var movieDtos = JsonConvert.DeserializeObject<ImportMovieDto[]>(jsonString);

            var movies = new List<Movie>();

            StringBuilder sb = new StringBuilder();

            foreach (var movieDto in movieDtos)
            {
                if (!IsValid(movieDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isGenreValid = Enum.TryParse<Genre>(movieDto.Genre, out Genre genre);

                var doesTitleExist = movies.Select(m => m.Title).ToArray().Contains(movieDto.Title);

                if (!isGenreValid || doesTitleExist)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = new Movie
                {
                    Title = movieDto.Title,
                    Genre = genre,
                    Duration = TimeSpan.ParseExact(movieDto.Duration, "hh\\:mm\\:ss", CultureInfo.InvariantCulture),
                    Rating = movieDto.Rating,
                    Director = movieDto.Director
                };

                movies.Add(movie);
                sb.AppendLine(string.Format(SuccessfulImportMovie, movieDto.Title, movieDto.Genre, $"{movieDto.Rating:f2}"));
            }

            context.Movies.AddRange(movies);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallDtos = JsonConvert.DeserializeObject<ImportHallDto[]>(jsonString);

            var halls = new List<Hall>();

            StringBuilder sb = new StringBuilder();

            foreach (var hallDto in hallDtos)
            {
                if (!IsValid(hallDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (hallDto.Seats <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name = hallDto.Name,
                    Is4Dx = hallDto.Is4Dx,
                    Is3D = hallDto.Is3D
                };

                for (int i = 0; i < hallDto.Seats; i++)
                {
                    hall.Seats.Add(new Seat
                    {
                        Hall = hall
                    });
                }

                string projectionType = string.Empty;

                if (hallDto.Is4Dx && hallDto.Is3D)
                {
                    projectionType = "4Dx/3D";
                }
                else if (!hallDto.Is4Dx && !hallDto.Is3D)
                {
                    projectionType = "Normal";
                }
                else if (hallDto.Is4Dx && !hallDto.Is3D)
                {
                    projectionType = "4Dx";
                }
                else
                {
                    projectionType = "3D";
                }

                halls.Add(hall);
                sb.AppendLine(string.Format(SuccessfulImportHallSeat, hallDto.Name, projectionType, hallDto.Seats));
            }

            context.Halls.AddRange(halls);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProjectionDto[]), new XmlRootAttribute("Projections"));
            var projectionDtos = (ImportProjectionDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var projections = new List<Projection>();

            foreach (var projectionDto in projectionDtos)
            {
                if (!IsValid(projectionDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = context.Movies.Find(projectionDto.MovieId);
                var hall = context.Halls.Find(projectionDto.HallId);

                if (movie == null || hall == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projection = new Projection
                {
                    Movie = movie,
                    Hall = hall,
                    DateTime = DateTime.ParseExact(projectionDto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };

                projections.Add(projection);

                string outputDateTime = projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

                sb.AppendLine(string.Format(SuccessfulImportProjection, projection.Movie.Title, outputDateTime));
            }

            context.Projections.AddRange(projections);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCutomerDto[]), new XmlRootAttribute("Customers"));
            var customerDtos = (ImportCutomerDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var customers = new List<Customer>();

            foreach (var customerDto in customerDtos)
            {
                if (!IsValid(customerDto) && !customerDto.Tickets.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (customerDto.Age < 12 || customerDto.Age > 110)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = new Customer
                {
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    Age = customerDto.Age,
                    Balance = customerDto.Balance
                };

                var tickets = new List<Ticket>();

                var areTicketsValid = true;

                foreach (var ticketDto in customerDto.Tickets)
                {
                    var projection = context.Projections.Find(ticketDto.ProjectionId);

                    if (projection == null)
                    {
                        areTicketsValid = false;
                        break;
                    }

                    tickets.Add(new Ticket
                    {
                        Price = ticketDto.Price,
                        Customer = customer,
                        Projection = projection
                    });
                }

                if (!areTicketsValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                customer.Tickets = tickets;

                customers.Add(customer);
                sb.AppendLine(string.Format(SuccessfulImportCustomerTicket, customerDto.FirstName, customerDto.LastName, customerDto.Tickets.Count()));
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return isValid;
        }
    }
}