namespace Cinema.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using Data;
    using ExportDto;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context.Movies
                .Where(m => m.Rating >= rating && m.Projections.Any(p => p.Tickets.Any()))
                .OrderByDescending(m => m.Rating)
                .ThenByDescending(m => m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)))
                .Select(m => new
                {
                    MovieName = m.Title,
                    Rating = $"{m.Rating:f2}",
                    TotalIncomes = $"{m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)):f2}",
                    Customers = m.Projections.SelectMany(p => p.Tickets).Select(t => new
                    {
                        FirstName = t.Customer.FirstName,
                        LastName = t.Customer.LastName,
                        Balance = $"{t.Customer.Balance:f2}"
                    })
                    .OrderByDescending(c => c.Balance)
                    .ThenBy(c => c.FirstName)
                    .ThenBy(c => c.LastName)
                    .ToArray()
                })
                .Take(10)
                .ToArray();

            var result = JsonConvert.SerializeObject(movies, Newtonsoft.Json.Formatting.Indented);

            return result;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var cutomers = context.Customers
                .Where(c => c.Age >= age)
                .Select(c => new ExportCustomerDto
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    SpentMoney = $"{c.Tickets.Sum(t => t.Price):f2}",
                    SpentTime = new TimeSpan(c.Tickets.Sum(t => t.Projection.Movie.Duration.Ticks)).ToString("hh\\:mm\\:ss", CultureInfo.InvariantCulture)
                })
                .OrderByDescending(c => decimal.Parse(c.SpentMoney))
                .Take(10)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportCustomerDto[]), new XmlRootAttribute("Customers"));

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty,
            });

            var sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), cutomers, namespaces);

            var result = sb.ToString().TrimEnd();

            return result;
        }
    }
}