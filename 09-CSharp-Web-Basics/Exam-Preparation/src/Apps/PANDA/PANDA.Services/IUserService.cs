namespace PANDA.Services
{
    using PANDA.Models;
    using System.Collections.Generic;

    public interface IUserService
    {
        User CreateUser(User user);

        User GetUserByUsernameAndPassword(string username, string password);

        User GetUserByUsername(string username);

        ICollection<string> GetAllUsernames();
    }
}
