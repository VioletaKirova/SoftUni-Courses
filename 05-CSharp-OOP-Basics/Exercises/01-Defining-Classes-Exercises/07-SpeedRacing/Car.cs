using System;
using System.Collections.Generic;
using System.Text;

namespace _07_SpeedRacing
{
    public class Car
    {
        //“<Model> <FuelAmount> <FuelConsumptionFor1km>”. All cars start at 0 kilometers traveled.

        private string model;
        private double fuelAmount;
        private double fuelConsumption;
        private double travelledDistance;

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumption = fuelConsumption;
            this.TravelledDistance = 0;
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public double FuelAmount
        {
            get { return this.fuelAmount; }
            set { this.fuelAmount = value; }
        }

        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }

        public double TravelledDistance
        {
            get { return this.travelledDistance; }
            set { this.travelledDistance = value; }
        }

        public bool CanMove(double distanceToMove)
        {
            return this.FuelAmount >= this.FuelConsumption * distanceToMove;
        }
    }
}
