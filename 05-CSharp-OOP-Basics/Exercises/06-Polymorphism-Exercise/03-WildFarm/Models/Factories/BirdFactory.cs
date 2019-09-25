using System;
using _03_WildFarm.Models.Birds;

namespace _03_WildFarm.Models.Factories
{
    public class BirdFactory
    {
        public Bird CreateBird(string type, string name, double weight, double wingSize)
        {
            if (type == "Owl")
            {
                return new Owl(name, weight, wingSize);
            }
            else if (type == "Hen")
            {
                return new Hen(name, weight, wingSize);
            }
            else
            {
                throw new ArgumentException("Ivalid bird type!");
            }
        }
    }
}
