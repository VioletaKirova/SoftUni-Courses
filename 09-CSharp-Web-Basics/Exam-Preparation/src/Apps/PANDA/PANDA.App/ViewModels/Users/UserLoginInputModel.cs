namespace PANDA.App.ViewModels.Users
{
    using SIS.MvcFramework.Attributes.Validation;

    public class UserLoginInputModel
    {
        [RequiredSis]
        public string Username { get; set; }

        [RequiredSis]
        public string Password { get; set; }
    }
}
