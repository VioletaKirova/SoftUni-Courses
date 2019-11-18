using System;

namespace _01_Vehicles.Models
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumpion)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumpion = fuelConsumpion;
        }

        public double FuelQuantity { get; protected set; }
        public double FuelConsumpion { get; protected set; }
        public virtual double AirConditionConsumption { get; private set; }

        public virtual void Refuel(double fuel)
        {
            this.FuelQuantity += fuel;
        }

        public void Drive(double distance)
        {
            double neededFuel = distance * this.FuelConsumpion;

            if (this.FuelQuantity < neededFuel)
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
                return;
            }

            this.FuelQuantity -= neededFuel;

            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
