namespace Instagraph.DataProcessor
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using Data;
    using Dto.Import;
    using Models;

    public class Deserializer
    {
        public static string ImportPictures(InstagraphContext context, string jsonString)
        {
            var pictureDtos = JsonConvert.DeserializeObject<ImportPictureDto[]>(jsonString);

            var pictures = new List<Picture>();

            StringBuilder sb = new StringBuilder();

            foreach (var pictureDto in pictureDtos)
            {
                if (!IsValid(pictureDto))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                pictures.Add(new Picture
                {
                    Path = pictureDto.Path,
                    Size = pictureDto.Size
                });

                sb.AppendLine($"Successfully imported Picture {pictureDto.Path}.");
            }

            context.Pictures.AddRange(pictures);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportUsers(InstagraphContext context, string jsonString)
        {
            var userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            var users = new List<User>();

            StringBuilder sb = new StringBuilder();

            foreach (var userDto in userDtos)
            {
                var picture = context.Pictures.FirstOrDefault(p => p.Path == userDto.ProfilePicture);

                if (!IsValid(userDto) || picture == null)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                users.Add(new User
                {
                    Username = userDto.Username,
                    Password = userDto.Password,
                    ProfilePicture = picture
                });

                sb.AppendLine($"Successfully imported User {userDto.Username}.");
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportFollowers(InstagraphContext context, string jsonString)
        {
            var followerDtos = JsonConvert.DeserializeObject<ImportFollowerDto[]>(jsonString);

            var usersFollowers = new List<UserFollower>();

            StringBuilder sb = new StringBuilder();

            foreach (var followerDto in followerDtos)
            {
                if (!IsValid(followerDto))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var user = context.Users.FirstOrDefault(u => u.Username == followerDto.User);
                var follower = context.Users.FirstOrDefault(f => f.Username == followerDto.Follower);

                if (user == null || follower == null)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var isUserFollowerUnique = true;

                foreach (var userFollower in usersFollowers)
                {
                    if (userFollower.Follower == follower && userFollower.User == user )
                    {
                        isUserFollowerUnique = false;
                        break;
                    }
                }

                if (!isUserFollowerUnique)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                usersFollowers.Add(new UserFollower
                {
                    Follower = follower,
                    User = user
                });

                sb.AppendLine($"Successfully imported Follower {follower.Username} to User {user.Username}.");
            }

            context.UsersFollowers.AddRange(usersFollowers);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportPosts(InstagraphContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportPostDto[]), new XmlRootAttribute("posts"));
            var postDtos = (ImportPostDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var posts = new List<Post>();

            var sb = new StringBuilder();

            foreach (var postDto in postDtos)
            {
                if (!IsValid(postDto))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var user = context.Users.FirstOrDefault(u => u.Username == postDto.User);
                var picture = context.Pictures.FirstOrDefault(p => p.Path == postDto.Picture);

                if (user == null || picture == null)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                posts.Add(new Post
                {
                    Caption = postDto.Caption,
                    User = user,
                    Picture = picture
                });

                sb.AppendLine($"Successfully imported Post {postDto.Caption}.");
            }

            context.Posts.AddRange(posts);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportComments(InstagraphContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCommentDto[]), new XmlRootAttribute("comments"));
            var commentDtos = (ImportCommentDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var comments = new List<Comment>();

            var sb = new StringBuilder();

            foreach (var commentDto in commentDtos)
            {
                if (!IsValid(commentDto))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var user = context.Users.FirstOrDefault(u => u.Username == commentDto.User);
                var post = context.Posts.FirstOrDefault(p => p.Id == commentDto.Post.Id);

                if (user == null || post == null)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                comments.Add(new Comment
                {
                    Content = commentDto.Content,
                    Post = post,
                    User = user
                });

                sb.AppendLine($"Successfully imported Comment {commentDto.Content}.");
            }

            context.Comments.AddRange(comments);
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
