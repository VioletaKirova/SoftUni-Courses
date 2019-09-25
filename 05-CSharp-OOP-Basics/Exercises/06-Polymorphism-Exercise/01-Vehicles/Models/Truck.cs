namespace _01_Vehicles.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumpion) 
            : base(fuelQuantity, fuelConsumpion)
        {
            this.FuelConsumpion += this.AirConditionConsumption;
        }

        public override double AirConditionConsumption => 1.6;

        public override void Refuel(double fuel)
        {
            this.FuelQuantity += fuel * 0.95;
        }
    }
}
