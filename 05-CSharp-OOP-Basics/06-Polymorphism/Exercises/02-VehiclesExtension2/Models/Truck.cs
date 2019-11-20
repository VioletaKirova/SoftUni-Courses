using System;

namespace _02_VehiclesExtension2.Models
{
    public class Truck : Vehicle
    {
        public const double airConditionConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumpion, double tankCapacity)
            : base(fuelQuantity, fuelConsumpion, tankCapacity)
        {
            this.FuelConsumpion += airConditionConsumption;
        }

        public override void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.FuelQuantity + fuel > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }

            this.FuelQuantity += fuel * 0.95;
        }
    }
}
