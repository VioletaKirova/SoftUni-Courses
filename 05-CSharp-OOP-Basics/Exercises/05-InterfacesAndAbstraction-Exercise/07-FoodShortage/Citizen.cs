
using _07_FoodShortage.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07_FoodShortage
{
    public class Citizen : ICitizen, IBuyer
    {
        public Citizen(string name, string age, string id, string birthday)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthday = birthday;
            Food = 0;
        }

        public string Name { get; set; }
        public string Age { get; set; }
        public string Id { get; set; }
        public string Birthday { get; set; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
