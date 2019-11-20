using System;
using System.Collections.Generic;

using _03_WildFarm.Models;
using _03_WildFarm.Models.Factories;
using _03_WildFarm.Models.Foods;

namespace _03_WildFarm.Core
{
    public class Engine
    {
        private FoodFactory foodFactory;
        private BirdFactory birdFactory;
        private MammalFactory mammalFactory;
        private FelineFactory felineFactory;
        IEnumerable<Animal> animals;

        public Engine()
        {
            this.foodFactory = new FoodFactory();
            this.birdFactory = new BirdFactory();
            this.mammalFactory = new MammalFactory();
            this.felineFactory = new FelineFactory();
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            while (true)
            {
                string[] animalArgs = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (animalArgs[0] == "End")
                {
                    break;
                }

                string[] foodArgs = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string type = animalArgs[0];
                string name = animalArgs[1];
                double weight = double.Parse(animalArgs[2]);

                Animal animal;

                if (type == "Owl" || type == "Hen")
                {
                    animal = birdFactory.CreateBird(type, name, weight, double.Parse(animalArgs[3]));
                }
                else if (type == "Mouse" || type == "Dog")
                {
                    animal = mammalFactory.CreateMammal(type, name, weight, animalArgs[3]);
                }
                else if (type == "Cat" || type == "Tiger")
                {
                    animal = felineFactory.CreateFeline(type, name, weight, animalArgs[3], animalArgs[4]);
                }
                else
                {
                    throw new ArgumentException("Invalid animal type!");
                }

                string foodType = foodArgs[0];
                int foodQuantity = int.Parse(foodArgs[1]);

                Food food = foodFactory.CreateFood(foodType, foodQuantity);

                animal.ProduceSound();

                try
                {
                    animal.EatFood(food);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                ((List<Animal>)animals).Add(animal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
