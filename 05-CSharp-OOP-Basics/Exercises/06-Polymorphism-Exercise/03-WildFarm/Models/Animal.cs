using _03_WildFarm.Models.Constracts;
using _03_WildFarm.Models.Foods;

namespace _03_WildFarm.Models
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public abstract void EatFood(Food food);

        public abstract void ProduceSound();
    }
}
