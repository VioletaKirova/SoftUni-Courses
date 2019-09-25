namespace MUSACA.Services
{
    using MUSACA.Models;

    public interface IUserService
    {
        User Create(User user);

        User GetUserByUsernameAndPassword(string username, string password);
    }
}
