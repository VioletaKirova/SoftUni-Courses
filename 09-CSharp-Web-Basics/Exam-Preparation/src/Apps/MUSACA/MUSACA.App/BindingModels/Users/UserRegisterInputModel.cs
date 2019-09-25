namespace MUSACA.App.BindingModels.Users
{
    using SIS.MvcFramework.Attributes.Validation;

    public class UserRegisterInputModel
    {
        private const string UsernameLengthErrorMessage = "Invalid username length! Must be between 5 and 20 symbols!";

        private const string EmailLengthErrorMessage = "Invalid email length! Must be between 5 and 50 symbols!";

        [RequiredSis]
        [StringLengthSis(5, 20, UsernameLengthErrorMessage)]
        public string Username { get; set; }

        [RequiredSis]
        public string Password { get; set; }

        [RequiredSis]
        public string ConfirmPassword { get; set; }

        [RequiredSis]
        [StringLengthSis(5, 50, EmailLengthErrorMessage)]
        [EmailSis]
        public string Email { get; set; }
    }
}
