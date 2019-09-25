using StorageMaster.Models.Products;
using StorageMaster.Models.Vehicles.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster.Models.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private int capacity;
        private IReadOnlyCollection<Product> trunk;
        private bool isFull;
        private bool isEmpty;

        public Vehicle()
        {
            this.Trunk = new List<Product>();
        }

        public Vehicle(int capacity)
            :this()
        {
            this.Capacity = capacity;
        }

        public int Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                capacity = value;
            }
        }

        public IReadOnlyCollection<Product> Trunk
        {
            get
            {
                return trunk;
            }
            set
            {
                trunk = value;
            }
        }

        public bool IsFull
        {
            get
            {
                return this.Trunk.Sum(x => x.Weight) >= this.Capacity ? true : false;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return this.Trunk.Count == 0 ? true : false;
            }
        }

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }

            ((List<Product>)this.Trunk).Add(product);
        }

        public Product Unload()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }

            Product unloadedProduct = ((List<Product>)this.Trunk)[this.Trunk.Count - 1];
            ((List<Product>)this.Trunk).RemoveAt(this.Trunk.Count - 1);

            return unloadedProduct;
        }
    }
}
