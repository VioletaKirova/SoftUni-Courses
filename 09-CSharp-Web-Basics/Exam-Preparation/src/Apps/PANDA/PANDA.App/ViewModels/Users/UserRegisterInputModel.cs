namespace PANDA.App.ViewModels.Users
{
    using SIS.MvcFramework.Attributes.Validation;

    public class UserRegisterInputModel
    {
        private const string UsernameStringLengthErrorMessage = "Username must be between 5 and 20 symbols.";
        private const string EmailStringLengthErrorMessage = "Email must be between 5 and 20 symbols.";

        [RequiredSis]
        [StringLengthSis(5,20, UsernameStringLengthErrorMessage)]
        public string Username { get; set; }

        [RequiredSis]
        public string Password { get; set; }

        [RequiredSis]
        public string ConfirmPassword { get; set; }

        [RequiredSis]
        [StringLengthSis(5, 20, EmailStringLengthErrorMessage)]
        public string Email { get; set; }
    }
}
