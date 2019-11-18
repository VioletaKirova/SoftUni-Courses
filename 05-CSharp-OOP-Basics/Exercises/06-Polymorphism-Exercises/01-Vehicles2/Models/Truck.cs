using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Vehicles2.Models
{
    public class Truck : Vehicle
    {
        public const double airConditionConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumpion) 
            : base(fuelQuantity, fuelConsumpion)
        {
            this.FuelConsumpion += airConditionConsumption;
        }
    }
}
