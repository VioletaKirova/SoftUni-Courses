using SULS.Models;

namespace SULS.Services
{
    public interface IUserService
    {
        User Create(User user);

        User GetUserByUsernameAndPassword(string username, string password);
    }
}
