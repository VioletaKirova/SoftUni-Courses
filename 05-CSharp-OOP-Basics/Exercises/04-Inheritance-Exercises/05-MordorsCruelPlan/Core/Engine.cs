using _05_MordorsCruelPlan.Factories;
using _05_MordorsCruelPlan.Foods;
using _05_MordorsCruelPlan.Moods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_MordorsCruelPlan.Core
{
    public class Engine
    {
        private FoodFactory foodFactory;
        private MoodFactory moodFactory;

        public Engine()
        {
            this.foodFactory = new FoodFactory();
            this.moodFactory = new MoodFactory();
        }

        public void Run()
        {
            try
            {
                string[] foods = Console.ReadLine().Split();

                int points = 0;

                foreach (var item in foods)
                {
                    string currentFood = item.ToLower();

                    Food food = foodFactory.CreateFood(currentFood);
                    points += food.Happiness;
                }

                Mood mood;

                if (points < -5)
                {
                    mood = moodFactory.CreateMood("angry");
                }
                else if (points >= -5 && points <= 0)
                {
                    mood = moodFactory.CreateMood("sad");
                }
                else if (points >= 1 && points <= 15)
                {
                    mood = moodFactory.CreateMood("happy");
                }
                else if (points > 15)
                {
                    mood = moodFactory.CreateMood("javascript");
                }
                else
                {
                    throw new Exception("Invalid points!");
                }

                Console.WriteLine(points);
                Console.WriteLine(mood.GetType().Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
