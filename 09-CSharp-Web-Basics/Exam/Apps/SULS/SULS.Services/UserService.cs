using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SULS.Data;
using SULS.Models;

namespace SULS.Services
{
    public class UserService : IUserService
    {
        private readonly SULSContext dbContext;

        public UserService(SULSContext dbContext)
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
                .SingleOrDefault(user => (user.Username == username || user.Email == username) &&
                                          user.Password == password);

            return userFromDb;
        }
    }
}
