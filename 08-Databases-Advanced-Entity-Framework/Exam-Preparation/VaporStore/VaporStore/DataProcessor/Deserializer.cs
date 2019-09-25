namespace VaporStore.DataProcessor
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
    using Dto.Import;

    public static class Deserializer
	{
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var gameDtos = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            var games = new List<Game>();

            StringBuilder sb = new StringBuilder();

            foreach (var gameDto in gameDtos)
            {
                if (!IsValid(gameDto) || gameDto.Tags.Length < 1)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = DateTime.ParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)
                };

                var developer = GetDeveloper(context, gameDto.Developer);
                game.Developer = developer;

                var genre = GetGenre(context, gameDto.Genre);
                game.Genre = genre;

                foreach (var tag in gameDto.Tags)
                {
                    var currentTag = GetTag(context, tag);

                    game.GameTags.Add(new GameTag
                    {
                        Game = game,
                        Tag = currentTag
                    });
                }

                games.Add(game);
                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }
       
        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
            var userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            var users = new List<User>();

            StringBuilder sb = new StringBuilder();

            foreach (var userDto in userDtos)
            {
                if (!IsValid(userDto) || userDto.Cards.Length == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var AreCardsValid = true;

                foreach (var cardDto in userDto.Cards)
                {
                    var isCardTypeValid = Enum.TryParse<CardType>(cardDto.Type, out CardType cardType);

                    if(!IsValid(cardDto) || !isCardTypeValid)
                    {
                        AreCardsValid = false;
                        break;
                    }
                }

                if (!AreCardsValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var user = new User
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age
                };

                foreach (var cardDto in userDto.Cards)
                {
                    user.Cards.Add(new Card
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.CVC,
                        Type = Enum.Parse<CardType>(cardDto.Type)
                    });
                }

                users.Add(user);
                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
            var xmlSerializer = new XmlSerializer(typeof(ImportPurchaseDto[]), new XmlRootAttribute("Purchases"));

            var purchaseDtos = (ImportPurchaseDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var purchases = new List<Purchase>();

            StringBuilder sb = new StringBuilder();

            foreach (var purchaseDto in purchaseDtos)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var isPurchaseType = Enum.TryParse<PurchaseType>(purchaseDto.Type, out PurchaseType purchaseType);
                var card = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.Card);
                var game = context.Games.FirstOrDefault(g => g.Name == purchaseDto.Title);

                if (!isPurchaseType || card == null || game == null)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var purchase = new Purchase
                {
                    Type = purchaseType,
                    ProductKey = purchaseDto.Key,
                    Date = DateTime.ParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Card = card,
                    Game = game
                };

                purchases.Add(purchase);
                sb.AppendLine($"Imported {game.Name} for {card.User.Username}");
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
		}

        private static Tag GetTag(VaporStoreDbContext context, string tagName)
        {
            var tag = context.Tags.FirstOrDefault(t => t.Name == tagName);

            if (tag == null)
            {
                tag = new Tag
                {
                    Name = tagName
                };

                context.Tags.Add(tag);
                context.SaveChanges();
            }

            return tag;
        }

        private static Genre GetGenre(VaporStoreDbContext context, string genreName)
        {
            var genre = context.Genres.FirstOrDefault(g => g.Name == genreName);

            if (genre == null)
            {
                genre = new Genre
                {
                    Name = genreName
                };

                context.Genres.Add(genre);
                context.SaveChanges();
            }

            return genre;
        }

        private static Developer GetDeveloper(VaporStoreDbContext context, string developerName)
        {
            var developer = context.Developers.FirstOrDefault(d => d.Name == developerName);

            if (developer == null)
            {
                developer = new Developer
                {
                    Name = developerName
                };

                context.Developers.Add(developer);
                context.SaveChanges();
            }

            return developer;
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