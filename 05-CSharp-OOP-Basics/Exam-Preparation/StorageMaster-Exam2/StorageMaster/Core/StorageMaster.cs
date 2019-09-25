using StorageMaster.Models.Products;
using StorageMaster.Models.Storages;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{  
    public class StorageMaster
    {
        private List<Product> products;
        private List<Storage> storages;
        private Vehicle currentVehicle;

        public StorageMaster()
        {
            this.products = new List<Product>();
            this.storages = new List<Storage>();
        }

        public string AddProduct(string type, double price)
        {
            Product product;

            switch (type)
            {
                case "Gpu":
                    product = new Gpu(price);
                    break;
                case "HardDrive":
                    product = new HardDrive(price);
                    break;
                case "Ram":
                    product = new Ram(price);
                    break;
                case "SolidStateDrive":
                    product = new SolidStateDrive(price);
                    break;
                default:
                    throw new InvalidOperationException("Invalid product type!");
            }

            this.products.Add(product);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage;

            switch (type)
            {
                case "AutomatedWarehouse":
                    storage = new AutomatedWarehouse(name);
                    break;
                case "DistributionCenter":
                    storage = new DistributionCenter(name);
                    break;
                case "Warehouse":
                    storage = new Warehouse(name);
                    break;
                default:
                    throw new InvalidOperationException("Invalid storage type!");
            }

            this.storages.Add(storage);

            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storages.FirstOrDefault(x => x.Name == storageName);

            Vehicle vehicle = storage.GetVehicle(garageSlot);

            this.currentVehicle = vehicle;

            return $"Selected {vehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedProductsCount = 0;

            foreach (var productName in productNames)
            {
                if (!this.products.Any(x => x.GetType().Name == productName))
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");
                }

                Product product = this.products.LastOrDefault(x => x.GetType().Name == productName);

                if (!currentVehicle.IsFull)
                {
                    loadedProductsCount++;
                    this.currentVehicle.LoadProduct(product);
                    this.products.Remove(product);
                }
            }

            return $"Loaded {loadedProductsCount}/{productNames.Count()} products into {currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            Storage sourceStorage = this.storages.FirstOrDefault(x => x.Name == sourceName);

            if (sourceStorage == null)
            {
                throw new InvalidOperationException("Invalid source storage!");
            }

            Storage destinationStorage = this.storages.FirstOrDefault(x => x.Name == destinationName);

            if (destinationStorage == null)
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            Vehicle vehicle = sourceStorage.GetVehicle(sourceGarageSlot);

            int destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            return $"Sent {vehicle.GetType().Name} to {destinationName} (slot {destinationGarageSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storages.FirstOrDefault(x => x.Name == storageName);

            Vehicle vehicle = storage.GetVehicle(garageSlot);

            int initialProductsCount = vehicle.Trunk.Count();
            int unloadedProductsCount = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProductsCount}/{initialProductsCount} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            Storage storage = this.storages.FirstOrDefault(x => x.Name == storageName);

            Dictionary<string, List<Product>> storageProducts = new Dictionary<string, List<Product>>();

            foreach (var product in storage.Products)
            {
                string productName = product.GetType().Name;

                if (!storageProducts.ContainsKey(productName))
                {
                    storageProducts[productName] = new List<Product>();
                }

                storageProducts[productName].Add(product);
            }

            StringBuilder sb = new StringBuilder();

            string[] productsAsStrings = storageProducts
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .Select(x => $"{x.Key} ({x.Value.Count})")
                .ToArray();

            //int productIndex = 0;
            //sb.AppendLine($"Stock ({storage.Products.Sum(x => x.Weight)}/{storage.Capacity}): [");
            //foreach (var productType in storageProducts.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            //{
            //    if (productIndex != storageProducts.Count - 1)
            //    {
            //        sb.Append($"{productType.Key} ({productType.Value.Count}), ");
            //    }
            //    else
            //    {
            //        sb.AppendLine($"{productType.Key} ({productType.Value.Count})]");
            //    }              
            //}

            sb.AppendLine($"Stock ({storage.Products.Sum(x => x.Weight)}/{storage.Capacity}): [{string.Join(',', productsAsStrings)}]");

            string[] storageVehiclesAsStrings = storage
                .Garage
                .Select(x => x == null ? "empty" : x.GetType().Name)
                .ToArray();

            sb.AppendLine($"Garage: [{string.Join('|', storageVehiclesAsStrings)}]");

            return sb.ToString().Trim();
        }

        public string GetSummary()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var storage in this.storages.OrderByDescending(x => x.Products.Sum(p => p.Price)))
            {
                double totalMoney = storage.Products.Sum(p => p.Price);

                sb.AppendLine($"{storage.Name}:");
                sb.AppendLine($"Storage worth: ${totalMoney:F2}");
            }

            return sb.ToString().Trim();
        }
    }
}
