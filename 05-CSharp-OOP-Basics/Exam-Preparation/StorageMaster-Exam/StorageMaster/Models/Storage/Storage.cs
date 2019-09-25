using StorageMaster.Models.Products;
using StorageMaster.Models.Storage.Contracts;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster.Models.Storage
{
    public abstract class Storage : IStorage
    {
        private string name;
        private int capacity;
        private int garageSlots;
        private bool isFull;
        private IEnumerable<Vehicle> garage;
        private IReadOnlyCollection<Product> products;

        public Storage(string name)
        {
            this.Name = name;
        }

        public Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> garage)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.Garage = garage;
            this.Products = new List<Product>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public int GarageSlots
        {
            get { return garageSlots; }
            set { garageSlots = value; }
        }

        public bool IsFull
        {
            get
            {
                return this.Products.Sum(x => x.Weight) >= this.Capacity ? true : false;
            }
        }

        public IEnumerable<Vehicle> Garage
        {
            get { return garage; }
            set { garage = value; }
        }

        public IReadOnlyCollection<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            if (((List<Vehicle>)this.Garage)[garageSlot] == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            Vehicle vehicle = ((List<Vehicle>)this.Garage)[garageSlot];
            return vehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = this.GetVehicle(garageSlot);

            if (!((List<Vehicle>)deliveryLocation.Garage).Any(x => x == null))
            {
                throw new InvalidOperationException("No room in garage!");
            }

            ((List<Vehicle>)this.Garage)[garageSlot] = null;

            int newGarageSlot = -1;

            for (int i = 0; i < ((List<Vehicle>)deliveryLocation.Garage).Count; i++)
            {
                if (((List<Vehicle>)deliveryLocation.Garage)[i] == null)
                {
                    newGarageSlot = i;
                    ((List<Vehicle>)deliveryLocation.Garage)[i] = vehicle;
                    break;
                }
            }

            return newGarageSlot;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            Vehicle vehicle = this.GetVehicle(garageSlot);

            int unloadedProductsCount = 0;

            while (!this.IsFull && !vehicle.IsEmpty)
            {
                unloadedProductsCount++;
                Product product = vehicle.Unload();
                ((List<Product>)this.Products).Add(product);
            }

            return unloadedProductsCount;
        }
    }
}
