namespace MUSACA.App.VeiwModels.Orders
{
    using MUSACA.App.VeiwModels.Products;
    using System.Collections.Generic;

    public class OrderIndexViewModel
    {
        public OrderIndexViewModel()
        {
            this.Products = new HashSet<ProductIndexViewModel>();
        }

        public ICollection<ProductIndexViewModel> Products { get; set; }

        public string TotalPrice { get; set; }
    }
}
