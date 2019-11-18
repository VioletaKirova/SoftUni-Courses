using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_PizzaCalories
{
    public class Pizza
    {
        private const int MIN_LEN = 1;
        private const int MAX_LEN = 15;
        private const int TOPPING_MIN_COUNT = 0;
        private const int TOPPING_MAX_COUNT = 10;

        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            Name = name;
            Toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value) || 15 < value.Length)
                {
                    NameException();
                }

                name = value;
            }
        }

        public Dough Dough
        {
            get
            {
                return dough;
            }
            set
            {
                dough = value;
            }
        }

        public List<Topping> Toppings
        {
            get
            {
                return toppings;
            }
            set
            {
                toppings = value;
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
            return Toppings.Sum(t => t.Calories) + Dough.Calories;
        }

        public void AddTopping(Topping topping)
        {
            if (Toppings.Count > TOPPING_MAX_COUNT)
            {
                ToppingCountExcpetion();
            }

            Toppings.Add(topping);
        }

        private static void ToppingCountExcpetion()
        {
            throw new ArgumentException($"Number of toppings should be in range [{TOPPING_MIN_COUNT}..{TOPPING_MAX_COUNT}].");
        }

        private static void NameException()
        {
            throw new ArgumentException($"Pizza name should be between {MIN_LEN} and {MAX_LEN} symbols.");
        }

        public override string ToString()
        {
            return $"{Name} - {Calories:f2} Calories.";
        }
    }
}