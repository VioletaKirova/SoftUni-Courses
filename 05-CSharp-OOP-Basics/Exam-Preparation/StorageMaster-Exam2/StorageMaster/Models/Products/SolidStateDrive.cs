﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Products
{
    public class SolidStateDrive : Product
    {
        private const double defaultWeight = 0.2;

        public SolidStateDrive(double price) 
            : base(price, defaultWeight)
        {
        }
    }
}
