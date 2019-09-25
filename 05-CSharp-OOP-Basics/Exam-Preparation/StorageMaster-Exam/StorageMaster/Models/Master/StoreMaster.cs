using StorageMaster.Factories;
using StorageMaster.Models.Master.Contracts;
using StorageMaster.Models.Products;
using StorageMaster.Models.Storage;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Master
{
    public class StoreMaster : IStoreMaster
    {
        private ProductFactory productMaker;
        private StorageFactory storageMaker;
        private VehicleFactory vehicleMaker;
        private ICollection<Product> productPool;
        private ICollection<Storage> storageRegistry;
        private Vehicle currentVehicle;

        public StoreMaster()
        {
            productMaker = new ProductFactory();
            storageMaker = new StorageFactory();
            vehicleMaker = new VehicleFactory();
            productPool = new List<Product>();
            storageRegistry = new List<Storage>();            
        }

        public string AddProduct(string type, double price)
        {
            Product product = productMaker.CreateProduct(type, price);
            productPool.Add(product);
            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = storageMaker.CreateStorage(type, name);
            storageRegistry.Add(storage);
            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            Storage storage = storageRegistry.FirstOrDefault(x => x.Name == storageName);
            currentVehicle = storage.GetVehicle(garageSlot);

            return $"Selected {currentVehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedProductsCount = 0;

            foreach (var productName in productNames)
            {               
                Product product = productPool.LastOrDefault(x => x.GetType().Name == productName);
                
                if (product == null )
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");                
                }
                else
                {
                    int productIndex = ((List<Product>)productPool).IndexOf(product);
                    ((List<Product>)productPool).RemoveAt(productIndex);

                    currentVehicle.LoadProduct(product);
                    loadedProductsCount++;

                    if (currentVehicle.IsFull)
                    {
                        break;
                    }
                }
            }

            return $"Loaded {loadedProductsCount}/{productNames.Count()} products into {currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (storageRegistry.FirstOrDefault(x => x.Name == sourceName) == null)
            {
                throw new InvalidOperationException("Invalid source storage!");
            }

            if (storageRegistry.FirstOrDefault(x => x.Name == destinationName) == null)
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            Storage sourceStorage = storageRegistry.FirstOrDefault(x => x.Name == sourceName);
            Storage destinationStorage = storageRegistry.FirstOrDefault(x => x.Name == destinationName);

            Vehicle vehicle = sourceStorage.GetVehicle(sourceGarageSlot);

            int destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            return $"Sent {vehicle.GetType().Name} to {destinationName} (slot {destinationGarageSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = storageRegistry.FirstOrDefault(x => x.Name == storageName);

            Vehicle vehicle = storage.GetVehicle(garageSlot);
            int productsInVehicle = vehicle.Trunk.Count();

            int unloadedProductsCount = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            Storage storage = storageRegistry.FirstOrDefault(x => x.Name == storageName);

            Dictionary<string, int> currentProducts = storage
                .Products
                .GroupBy(x => x.GetType().Name)
                .ToDictionary(x => x.Key, x => x.ToList().Count);

            currentProducts = currentProducts
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            List<string> currentVehicles = new List<string>();

            foreach (var vehicle in (List<Vehicle>)storage.Garage)
            {
                if (vehicle == null)
                {
                    currentVehicles.Add("empty");
                }
                else
                {
                    currentVehicles.Add(vehicle.GetType().Name);
                }
            }

            double productsWeight = storage.Products.Sum(x => x.Weight);

            int productCounter = -1;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Stock ({productsWeight}/{storage.Capacity}): [");

            foreach (var product in currentProducts)
            {
                productCounter++;

                if (productCounter == currentProducts.Count - 1)
                {
                    stringBuilder.Append($"{product.Key} ({product.Value})");
                }
                else
                {
                    stringBuilder.Append($"{product.Key} ({product.Value}), ");
                }
            }

            stringBuilder.Append("]").AppendLine();
            stringBuilder.AppendLine($"Garage: [{string.Join('|', currentVehicles)}]");

            return stringBuilder.ToString().Trim();
        }

        public string GetSummary()
        {
            List<Storage> orderedStorages = storageRegistry
                .OrderByDescending(x => x.Products.Sum(p => p.Price))
                .ToList();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var storage in orderedStorages)
            {
                double totalMoney = storage.Products.Sum(p => p.Price);

                stringBuilder.AppendLine($"{storage.Name}:");
                stringBuilder.AppendLine($"Storage worth: ${totalMoney:F2}");
            }

            return stringBuilder.ToString().Trim();
        }

    }
}
