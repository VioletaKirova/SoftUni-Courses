using _01_Vehicles2.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Vehicles2.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumpion;

        protected Vehicle(double fuelQuantity, double fuelConsumpion)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumpion = fuelConsumpion;
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            private set { fuelQuantity = value; }
        }

        public double FuelConsumpion
        {
            get { return fuelConsumpion; }
            protected set { fuelConsumpion = value; }
        }


        public void Refuel(double fuel)
        {
            if (this is Truck)
            {
                fuel *= 0.95;
            }

            this.FuelQuantity += fuel;
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
