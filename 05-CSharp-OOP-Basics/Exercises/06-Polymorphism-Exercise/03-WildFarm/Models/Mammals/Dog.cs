using System;
using _03_WildFarm.Models.Foods;

namespace _03_WildFarm.Models.Mammals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void EatFood(Food food)
        {
            if (food is Meat)
            {
                this.Weight += 0.4 * food.Quantity;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"Dog does not eat {food.GetType().Name}!");
            }
        }

        public void GainWeight(int quantity)
        {
            this.Weight += 0.4 * quantity;
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Woof!");
        }
    }
}
