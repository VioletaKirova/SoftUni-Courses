using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Products
{
    public class SolidStateDrive : Product
    {
        private const double productWeight = 0.2;

        public SolidStateDrive(double price) 
            : base(price)
        {
            this.Weight = productWeight;
        }
    }
}
