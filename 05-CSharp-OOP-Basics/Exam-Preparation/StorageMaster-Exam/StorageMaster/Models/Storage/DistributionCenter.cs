using StorageMaster.Models.Products;
using StorageMaster.Models.Vehicles;
using System.Collections.Generic;

namespace StorageMaster.Models.Storage
{
    public class DistributionCenter : Storage
    {
        public DistributionCenter(string name)
            : base(name)
        {
            this.Capacity = 2;
            this.GarageSlots = 5;
            this.Garage = new List<Vehicle>(5)
            {
                new Van(),
                new Van(),
                new Van(), 
                null,
                null
            };

            this.Products = new List<Product>();
        }
    }
}
