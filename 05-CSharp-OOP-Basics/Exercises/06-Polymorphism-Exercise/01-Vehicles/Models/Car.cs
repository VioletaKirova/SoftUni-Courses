namespace _01_Vehicles.Models
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumpion) 
            : base(fuelQuantity, fuelConsumpion)
        {
            this.FuelConsumpion += this.AirConditionConsumption;
        }

        public override double AirConditionConsumption => 0.9;
    }
}
