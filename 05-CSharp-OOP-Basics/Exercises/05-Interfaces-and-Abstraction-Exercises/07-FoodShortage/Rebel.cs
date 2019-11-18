using _07_FoodShortage.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07_FoodShortage
{
    public class Rebel : IRebel, IBuyer
    {
        public Rebel(string name, string age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
            Food = 0;
        }

        public string Name { get; set; }
        public string Age { get; set; }
        public string Group { get; set; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
