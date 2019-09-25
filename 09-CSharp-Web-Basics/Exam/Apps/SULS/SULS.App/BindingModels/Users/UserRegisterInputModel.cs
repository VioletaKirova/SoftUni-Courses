namespace SULS.App.BindingModels.Users
{
    using SIS.MvcFramework.Attributes.Validation;

    public class UserRegisterInputModel
    {
        private const string UsernameLengthErrorMessage = "Invalid username length! Must be between 5 and 20 symbols!";

        private const string PasswordLengthErrorMessage = "Invalid password length! Must be between 6 and 20 symbols!";

        [RequiredSis]
        [StringLengthSis(5, 20, UsernameLengthErrorMessage)]
        public string Username { get; set; }

        [RequiredSis]
        [StringLengthSis(6, 20, PasswordLengthErrorMessage)]
        public string Password { get; set; }

        [RequiredSis]
        [StringLengthSis(6, 20, PasswordLengthErrorMessage)]
        public string ConfirmPassword { get; set; }

        [RequiredSis]
        [EmailSis]
        public string Email { get; set; }
    }
}
