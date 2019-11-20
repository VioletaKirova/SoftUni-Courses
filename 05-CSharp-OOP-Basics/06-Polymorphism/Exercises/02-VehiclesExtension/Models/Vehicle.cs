using System;

namespace _02_VehiclesExtension.Models
{
    public abstract class Vehicle
    {
        private double fuelQuantity;

        public Vehicle()
        {

        }

        protected Vehicle(double fuelQuantity, double fuelConsumpion, double tankCapacity)
        {
            this.FuelConsumpion = fuelConsumpion;
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
        }

        public double FuelQuantity
        {
            get
            {
                return fuelQuantity;
            }
            set
            {
                if (value > this.TankCapacity)
                {
                    fuelQuantity = 0;
                    return;
                }

                fuelQuantity = value;
            }
        }

        public double FuelConsumpion { get; protected set; }
        public double TankCapacity { get; protected set; }
        public virtual double AirConditionConsumption { get; private set; }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.fuelQuantity + fuel > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }           
        }

        public void Drive(double distance)
        {
            double neededFuel = distance * this.FuelConsumpion;

            if (this.FuelQuantity < neededFuel)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
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
