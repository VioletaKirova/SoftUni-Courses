namespace Instagraph.DataProcessor
{
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using Data;
    using Dto.Export;

    public class Serializer
    {
        public static string ExportUncommentedPosts(InstagraphContext context)
        {
            var posts = context.Posts
                .Where(p => !p.Comments.Any())
                .Select(p => new
                {
                    Id = p.Id,
                    Picture = p.Picture.Path,
                    User = p.User.Username
                })
                .OrderBy(p => p.Id)
                .ToArray();

            var result = JsonConvert.SerializeObject(posts, Newtonsoft.Json.Formatting.Indented);

            return result;
        }

        public static string ExportPopularUsers(InstagraphContext context)
        {
            var users = context.Users
                .Where(u => u.Posts.Any(p => p.Comments.Any(c => u.Followers.Select(f => f.Follower).Contains(c.User))))
                .OrderBy(u => u.Id)
                .Select(u => new
                {
                    Username = u.Username,
                    Followers = u.Followers.Count
                })
                .ToArray();

            var result = JsonConvert.SerializeObject(users, Newtonsoft.Json.Formatting.Indented);

            return result;
        }

        public static string ExportCommentsOnPosts(InstagraphContext context)
        {
            var users = context.Users
                .Select(u => new ExportUserMostCommentsDto
                {
                    Username = u.Username,
                    MostComments = u.Posts.Any() == false ? 0 : u.Posts.OrderByDescending(p => p.Comments.Count).First().Comments.Count
                })
                .OrderByDescending(u => u.MostComments)
                .ThenBy(u => u.Username)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportUserMostCommentsDto[]), new XmlRootAttribute("users"));

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty,
            });

            var sb = new StringBuilder();
            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            var result = sb.ToString().TrimEnd();

            return result;
        }
    }
}
