using StorageMaster.Models.Products;
using StorageMaster.Models.Products.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Vehicles.Contracts
{
    public interface IVehicle
    {
        int Capacity { get; }

        IReadOnlyCollection<Product> Trunk { get; }

        bool IsFull { get; }

        bool IsEmpty { get; }

        void LoadProduct(Product product);

        Product Unload();
    }
}
