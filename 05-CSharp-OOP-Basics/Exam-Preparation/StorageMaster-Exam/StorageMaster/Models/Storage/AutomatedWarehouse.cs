using StorageMaster.Models.Products;
using StorageMaster.Models.Vehicles;
using System.Collections.Generic;

namespace StorageMaster.Models.Storage
{
    public class AutomatedWarehouse : Storage
    {
        public AutomatedWarehouse(string name) 
            : base(name)
        {
            this.Capacity = 1;
            this.GarageSlots = 2;
            this.Garage = new List<Vehicle>(2) { new Truck(), null };
            this.Products = new List<Product>();
        }
    }
}
