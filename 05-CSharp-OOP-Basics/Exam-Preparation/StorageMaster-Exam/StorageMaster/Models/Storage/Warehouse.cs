using StorageMaster.Models.Products;
using StorageMaster.Models.Vehicles;
using System.Collections.Generic;

namespace StorageMaster.Models.Storage
{
    public class Warehouse : Storage
    {
        public Warehouse(string name) 
            : base(name)
        {
            this.Capacity = 10;
            this.GarageSlots = 10;
            this.Garage = new List<Vehicle>(10)
            {
                new Semi(),
                new Semi(),
                new Semi(),
                null,
                null,
                null,
                null,
                null,
                null,
                null,
            };

            this.Products = new List<Product>();
        }
    }
}
