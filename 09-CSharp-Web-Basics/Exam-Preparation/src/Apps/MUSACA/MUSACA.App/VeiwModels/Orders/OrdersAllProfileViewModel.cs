namespace MUSACA.App.VeiwModels.Orders
{
    using System.Collections.Generic;

    public class OrdersAllProfileViewModel
    {
        public OrdersAllProfileViewModel()
        {
            this.Orders = new List<OrderAllProfileViewModel>();
        }

        public ICollection<OrderAllProfileViewModel> Orders { get; set; }
    }
}
