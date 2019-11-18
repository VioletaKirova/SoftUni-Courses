using System;
using _03_WildFarm.Models.Foods;

namespace _03_WildFarm.Models.Mammals.Felines
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void EatFood(Food food)
        {
            if (food is Vegetable || food is Meat)
            {
                this.Weight += 0.3 * food.Quantity;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"Cat does not eat {food.GetType().Name}!");
            }
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }    
}
