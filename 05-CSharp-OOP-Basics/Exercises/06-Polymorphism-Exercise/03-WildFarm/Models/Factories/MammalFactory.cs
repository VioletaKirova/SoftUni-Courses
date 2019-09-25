using System;
using _03_WildFarm.Models.Mammals;

namespace _03_WildFarm.Models.Factories
{
    public class MammalFactory
    {
        public Mammal CreateMammal(string type, string name, double weight, string livingRegion)
        {
            if (type == "Dog")
            {
                return new Dog(name, weight, livingRegion);
            }
            else if (type == "Mouse")
            {
                return new Mouse(name, weight, livingRegion);
            }
            else
            {
                throw new ArgumentException("Ivalid mammal type!");
            }
        }
    }
}
