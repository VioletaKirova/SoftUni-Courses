using System;
using System.Collections.Generic;
using System.Text;

namespace _03_AnimalFarm
{
    public class Chicken
    {
        private string name;
        private int age;
        private double productPerDay;

        public Chicken(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.ProductPerDay = productPerDay;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value == null || value == string.Empty || value == " ")
                {
                    throw new ArgumentException("Name cannot be empty.");
                }

                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0 || value > 15)
                {
                    throw new ArgumentException("Age should be between 0 and 15.");
                }

                age = value;
            }
        }

        public double ProductPerDay
        {
            get { return productPerDay; }
            set { productPerDay = CalculateProductPerDay(); }
        }

        private double CalculateProductPerDay()
        {
            if (this.Age >= 0 && this.Age <= 3)
            {
                return 1.5;
            }
            else if (this.Age >= 4 && this.Age <= 7)
            {
                return 2;
            }
            else if (this.Age >= 8 && this.Age <= 11)
            {
                return 1;
            }
            else
            {
                return 0.75;
            }
        }

        public override string ToString()
        {
            return $"Chicken {this.Name} (age {this.Age}) can produce {this.ProductPerDay} eggs per day.";
        }
    }
}
