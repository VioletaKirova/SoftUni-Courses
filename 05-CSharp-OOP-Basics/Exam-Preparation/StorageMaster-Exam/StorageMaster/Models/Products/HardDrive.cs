using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Products
{
    public class HardDrive : Product
    {
        private const double productWeight = 1.0;

        public HardDrive(double price) 
            : base(price)
        {
            this.Weight = productWeight;
        }
    }
}
