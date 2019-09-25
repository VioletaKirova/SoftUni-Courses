namespace _02_VehiclesExtension.Models
{
    public class Truck : Vehicle
    {
        public Truck()
        {

        }

        public Truck(double fuelQuantity, double fuelConsumpion, double tankCapacity)
            : base(fuelQuantity, fuelConsumpion, tankCapacity)
        {
            this.FuelConsumpion += this.AirConditionConsumption;
        }

        public override double AirConditionConsumption => 1.6;

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel);

            this.FuelQuantity += fuel * 0.95;
        }
    }
}
