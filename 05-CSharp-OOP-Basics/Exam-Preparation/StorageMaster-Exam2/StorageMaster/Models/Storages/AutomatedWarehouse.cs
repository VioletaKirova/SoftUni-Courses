using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storages
{
    public class AutomatedWarehouse : Storage
    {
        private const int defaultCapacity = 1;
        private const int defaultGarageSlots = 2;

        public AutomatedWarehouse(string name) 
            : base(name, defaultCapacity, defaultGarageSlots, new Vehicle[] { new Truck() })
        {
        }
    }
}
