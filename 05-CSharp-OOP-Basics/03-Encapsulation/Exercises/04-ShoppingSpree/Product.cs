using System;
using System.Collections.Generic;
using System.Text;

namespace _04_ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get { return name; }
            set
            {
                NameException(value);

                name = value;
            }
        }

        public decimal Cost
        {
            get { return cost; }
            set
            {
                CostException(value);

                cost = value;
            }
        }

        private void CostException(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
        }

        private static void NameException(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
        }
    }
}
