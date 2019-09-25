using StorageMaster.Models.Products.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Products
{
    public abstract class Product : IProduct
    {
        private double price;
        private double weight;
       
        protected Product(double price, double weight)
            :this(price)
        {
            this.Weight = weight;
        }

        protected Product(double price)
        {
            this.Price = price;
        }

        public double Price
        {
            get
            {
                return price;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Price cannot be negative!");
                }

                price = value;
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }
            protected set
            {
                weight = value;
            }
        }
    }
}
