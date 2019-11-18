namespace _02_VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        public Car()
        {

        }

        public Car(double fuelQuantity, double fuelConsumpion, double tankCapacity)
            : base(fuelQuantity, fuelConsumpion, tankCapacity)
        {
            this.FuelConsumpion += this.AirConditionConsumption;
        }

        public override double AirConditionConsumption => 0.9;

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel);

            this.FuelQuantity += fuel;
        }
    }
}
