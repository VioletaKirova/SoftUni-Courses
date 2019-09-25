using System;
using System.Collections.Generic;
using System.Text;

namespace _02_VehiclesExtension2.Models.Contracts
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumpion { get; }
        double TankCapacity { get; }
        bool IsVehicleEmpty { get; set; }

        void Drive(double distance);
        void Refuel(double fuel);
    }
}
