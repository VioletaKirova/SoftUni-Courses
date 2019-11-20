using System;
using _03_WildFarm.Models.Foods;

namespace _03_WildFarm.Models.Birds
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void EatFood(Food food)
        {
            this.Weight += 0.35 * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Cluck");
        }
    }
}
