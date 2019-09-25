namespace MUSACA.App.BindingModels.Products
{
    using SIS.MvcFramework.Attributes.Validation;

    public class ProductCreateInputModel
    {
        private const string NameLengthErrorMessage = "Invalid name length! Must be between 3 and 10 symbols!";

        private const string PriceRangeErrorMessage = "Invalid price! Must be between $0.01 and $1 000 000!";

        [RequiredSis]
        [StringLengthSis(3, 10, NameLengthErrorMessage)]
        public string Name { get; set; }

        [RequiredSis]
        [RangeSis(typeof(decimal), "0.01", "1000000", PriceRangeErrorMessage)]
        public decimal Price { get; set; }
    }
}
