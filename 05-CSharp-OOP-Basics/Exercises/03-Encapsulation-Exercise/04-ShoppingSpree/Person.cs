using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.Products = new List<Product>();
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

        public decimal Money
        {
            get { return money; }
            set
            {
                MoneyException(value);

                money = value;
            }
        }

        public List<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        private void MoneyException(decimal value)
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

        public override string ToString()
        {
            if (this.Products.Any())
            {
                return $"{this.Name} - {string.Join(", ", this.Products.Select(p => p.Name))}";
            }
            else
            {
                return $"{this.Name} - Nothing bought";
            }
        }
    }
}
