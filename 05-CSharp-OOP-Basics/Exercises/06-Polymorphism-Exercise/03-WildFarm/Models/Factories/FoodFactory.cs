using System;
using _03_WildFarm.Models.Foods;

namespace _03_WildFarm.Models.Factories
{
    public class FoodFactory
    {
        public Food CreateFood(string type, int quantity)
        {
            type = type.ToLower();

            if (type == "vegetable")
            {
                return new Vegetable(quantity);
            }
            else if (type == "fruit")
            {
                return new Fruit(quantity);
            }
            else if (type == "meat")
            {
                return new Meat(quantity);
            }
            else if (type == "seeds")
            {
                return new Seeds(quantity);
            }
            else
            {
                throw new ArgumentException("Invalid food type!");
            }
        }
    }
}
