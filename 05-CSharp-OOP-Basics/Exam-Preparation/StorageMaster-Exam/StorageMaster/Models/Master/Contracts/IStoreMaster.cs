using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Master.Contracts
{
    public interface IStoreMaster
    {
        string AddProduct(string type, double price);

        string RegisterStorage(string type, string name);

        string SelectVehicle(string storageName, int garageSlot);

        string LoadVehicle(IEnumerable<string> productNames);

        string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName);

        string UnloadVehicle(string storageName, int garageSlot);

        string GetStorageStatus(string storageName);

        string GetSummary();
    }
}
