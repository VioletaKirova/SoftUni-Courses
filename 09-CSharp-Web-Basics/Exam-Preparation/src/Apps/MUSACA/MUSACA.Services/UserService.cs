namespace MUSACA.Services
{
    using MUSACA.Data;
    using MUSACA.Models;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly MusacaDbContext dbContext;

        public UserService(MusacaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public User Create(User user)
        {
            var userFromDb = this.dbContext.Users.Add(user).Entity;
            this.dbContext.SaveChanges();

            return userFromDb;
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            var userFromDb = this.dbContext.Users
                .SingleOrDefault(user => user.Username == username && user.Password == password);

            return userFromDb;
        }
    }
}
