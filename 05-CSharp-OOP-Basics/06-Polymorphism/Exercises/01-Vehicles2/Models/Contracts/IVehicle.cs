using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Vehicles2.Models.Contracts
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumpion { get;  }

        void Drive(double distance);
        void Refuel(double fuel);
    }
}
