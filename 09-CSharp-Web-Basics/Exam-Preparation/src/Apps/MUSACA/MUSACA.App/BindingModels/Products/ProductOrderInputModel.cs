namespace MUSACA.App.BindingModels.Products
{
    using SIS.MvcFramework.Attributes.Validation;

    public class ProductOrderInputModel
    {
        private const string ProductNameErrorMessage = "Invalid name length! Must be between 3 and 10 symbols!";

        [RequiredSis]
        [StringLengthSis(3, 10, ProductNameErrorMessage)]
        public string Product { get; set; }
    }
}
