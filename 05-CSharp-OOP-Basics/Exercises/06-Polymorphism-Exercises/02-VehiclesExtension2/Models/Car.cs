namespace _02_VehiclesExtension2.Models
{
    public class Car : Vehicle
    {
        public const double airConditionConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumpion, double tankCapacity)
            : base(fuelQuantity, fuelConsumpion, tankCapacity)
        {
            this.FuelConsumpion += airConditionConsumption;
        }
    }
}
