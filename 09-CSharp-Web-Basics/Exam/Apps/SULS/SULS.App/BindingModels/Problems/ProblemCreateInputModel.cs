namespace SULS.App.BindingModels.Problems
{
    using SIS.MvcFramework.Attributes.Validation;

    public class ProblemCreateInputModel
    {
        private const string NameLengthErrorMessage = "Invalid name length! Must be between 5 and 20 symbols!";

        private const string PointsRangeErrorMessage = "Invalid points! Must be between 50 and 300!";

        [RequiredSis]
        [StringLengthSis(5, 20, NameLengthErrorMessage)]
        public string Name { get; set; }

        [RequiredSis]
        [RangeSis(50, 300, PointsRangeErrorMessage)]
        public int Points { get; set; }
    }
}
