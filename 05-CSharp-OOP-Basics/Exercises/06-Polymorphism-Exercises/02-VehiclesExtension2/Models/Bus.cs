using System;

namespace _02_VehiclesExtension2.Models
{
    public class Bus : Vehicle
    {
        private const double airConditionConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumpion, double tankCapacity) 
            : base(fuelQuantity, fuelConsumpion, tankCapacity)
        {
        }

        public override void Drive(double distance)
        {
            double currentFuelConsumption = this.FuelConsumpion;

            if (!IsVehicleEmpty)
            {
                currentFuelConsumption += airConditionConsumption;
            }

            double neededFuel = distance * currentFuelConsumption;

            if (this.FuelQuantity < neededFuel)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= neededFuel;

            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }
    }
}
