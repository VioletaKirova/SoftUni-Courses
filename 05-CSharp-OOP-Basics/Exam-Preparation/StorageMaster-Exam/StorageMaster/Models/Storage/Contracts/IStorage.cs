using StorageMaster.Models.Products;
using StorageMaster.Models.Vehicles;
using System.Collections.Generic;

namespace StorageMaster.Models.Storage.Contracts
{
    public interface IStorage
    {
        string Name { get; }

        int Capacity { get; }

        int GarageSlots { get; }

        bool IsFull { get; }

        IEnumerable<Vehicle> Garage { get; }

        IReadOnlyCollection<Product> Products { get; }

        Vehicle GetVehicle(int garageSlot);

        int SendVehicleTo(int garageSlot, Storage deliveryLocation);

        int UnloadVehicle(int garageSlot);
    }
}
