using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Vehicles
{
    public class Semi : Vehicle
    {
        private const int defaultCapacity = 10;

        public Semi() 
            : base(defaultCapacity)
        {
        }
    }
}
