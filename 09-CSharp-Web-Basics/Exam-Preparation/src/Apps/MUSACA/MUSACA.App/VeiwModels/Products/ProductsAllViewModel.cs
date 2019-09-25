namespace MUSACA.App.VeiwModels.Products
{
    using System.Collections.Generic;

    public class ProductsAllViewModel
    {
        public ProductsAllViewModel()
        {
            this.Products = new List<ProductAllViewModel>();
        }

        public ICollection<ProductAllViewModel> Products { get; set; }
    }
}
