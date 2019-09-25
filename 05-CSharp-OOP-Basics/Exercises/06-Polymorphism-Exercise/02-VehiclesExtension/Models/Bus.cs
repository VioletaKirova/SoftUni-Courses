using System;
using System.Collections.Generic;
using System.Text;

namespace _02_VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        public Bus()
        {

        }

        public Bus(double fuelQuantity, double fuelConsumpion, double tankCapacity) 
            : base(fuelQuantity, fuelConsumpion, tankCapacity)
        {
        }

        public void IncreaseFuelConsumption()
        {
            this.FuelConsumpion += this.AirConditionConsumption;
        }

        public override double AirConditionConsumption => 1.4;
    }
}
