namespace PANDA.Services
{
    using PANDA.Data;
    using PANDA.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly PandaDbContext dbContext;

        public UserService(PandaDbContext pandaDbContext)
        {
            this.dbContext = pandaDbContext;
        }

        public User CreateUser(User user)
        {
            var userForDb = this.dbContext.Users.Add(user).Entity;
            this.dbContext.SaveChanges();

            return userForDb;
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return dbContext.Users
                .SingleOrDefault(u => u.Username == username && u.Password == password);
        }

        public User GetUserByUsername(string username)
        {
            return dbContext.Users
                .SingleOrDefault(u => u.Username == username);
        }

        public ICollection<string> GetAllUsernames()
        {
            return this.dbContext.Users.Select(u => u.Username).ToList();
        }
    }
}
