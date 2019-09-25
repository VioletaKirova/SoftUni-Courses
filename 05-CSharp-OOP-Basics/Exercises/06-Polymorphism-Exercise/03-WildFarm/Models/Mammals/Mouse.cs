using System;
using _03_WildFarm.Models.Foods;

namespace _03_WildFarm.Models.Mammals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void EatFood(Food food)
        {
            if (food is Vegetable || food is Fruit)
            {
                this.Weight += 0.1 * food.Quantity;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"Mouse does not eat {food.GetType().Name}!");
            }
        }

        public void GainWeight(int quantity)
        {
            this.Weight += 0.1 * quantity;
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Squeak");
        }
    }
}
