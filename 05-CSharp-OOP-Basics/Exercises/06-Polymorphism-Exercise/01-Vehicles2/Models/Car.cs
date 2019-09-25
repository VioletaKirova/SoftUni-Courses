using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Vehicles2.Models
{
    public class Car : Vehicle
    {
        public const double airConditionConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumpion) 
            : base(fuelQuantity, fuelConsumpion)
        {
            this.FuelConsumpion += airConditionConsumption;
        }
    }
}
