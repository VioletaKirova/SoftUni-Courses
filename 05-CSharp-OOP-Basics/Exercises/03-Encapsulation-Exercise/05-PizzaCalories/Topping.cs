using System;

namespace P05_PizzaCalories
{
    public class Topping
    {
        private const int MIN_VALUE = 1;
        private const int MAX_VALUE = 50;
        private const int BASE_CALS = 2;

        private string type;
        private double weight;
        private double calories;

        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;
        }

        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                if (value.ToLower() != "meat" &&
                    value.ToLower() != "veggies" &&
                    value.ToLower() != "cheese" &&
                    value.ToLower() != "sauce")
                {
                    TypeException(value);
                }

                type = value;
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value < MIN_VALUE || value > MAX_VALUE)
                {
                    WeightException();
                }

                weight = value;
            }
        }

        public double Calories
        {
            get
            {
                return CalculateCalories();
            }
        }

        private double CalculateCalories()
        {
            double modifier = 0.0;

            switch (Type.ToLower())
            {
                case "meat":
                    modifier = 1.2;
                    break;

                case "veggies":
                    modifier = 0.8;
                    break;

                case "cheese":
                    modifier = 1.1;
                    break;

                case "sauce":
                    modifier = 0.9;
                    break;
            }

            return (Weight * BASE_CALS) * modifier;
        }

        private static void TypeException(string value)
        {
            throw new ArgumentException($"Cannot place {value} on top of your pizza.");
        }

        private void WeightException()
        {
            throw new ArgumentException($"{Type} weight should be in the range [{MIN_VALUE}..{MAX_VALUE}].");
        }
    }
}