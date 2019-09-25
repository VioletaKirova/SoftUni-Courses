namespace StorageMaster.Models.Vehicles
{
    public class Truck : Vehicle
    {
        private const int capacity = 5;

        public Truck()
        {
            this.Capacity = capacity;
        }
    }
}
