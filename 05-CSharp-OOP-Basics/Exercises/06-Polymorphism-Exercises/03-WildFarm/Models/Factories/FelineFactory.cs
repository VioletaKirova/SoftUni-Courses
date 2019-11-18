using System;
using _03_WildFarm.Models.Mammals.Felines;

namespace _03_WildFarm.Models.Factories
{
    public class FelineFactory
    {
        public Feline CreateFeline(string type, string name, double weight, string livingRegion, string breed)
        {
            if (type == "Cat")
            {
                return new Cat(name, weight, livingRegion, breed);
            }
            else if (type == "Tiger")
            {
                return new Tiger(name, weight, livingRegion, breed);
            }
            else
            {
                throw new ArgumentException("Ivalid feline type!");
            }
        }
    }
}
