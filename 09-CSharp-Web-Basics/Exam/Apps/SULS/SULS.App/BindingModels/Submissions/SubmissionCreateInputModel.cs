namespace SULS.App.BindingModels.Submissions
{
    using SIS.MvcFramework.Attributes.Validation;

    public class SubmissionCreateInputModel
    {
        private const string CodeLengthErrorMessage = "Invalid code length! Must be between 30 and 800 symbols!";

        public string ProblemId { get; set; }

        [RequiredSis]
        [StringLengthSis(30, 800, CodeLengthErrorMessage)]
        public string Code { get; set; }
    }
}
