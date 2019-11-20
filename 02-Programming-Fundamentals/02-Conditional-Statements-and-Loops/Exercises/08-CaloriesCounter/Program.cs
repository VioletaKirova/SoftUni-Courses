using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_CaloriesCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var calsInCheese = 500;
            var calsInSauce = 150;
            var calsInSalami = 600;
            var calsInPepper = 50;

            var calories = 0;

            for (int i = 0; i < n; i++)
            {
                var ingredient = Console.ReadLine().ToLower();

                if (ingredient == "cheese")
                {
                    calories += calsInCheese;
                }
                else if (ingredient == "tomato sauce")
                {
                    calories += calsInSauce;
                }
                else if (ingredient == "salami")
                {
                    calories += calsInSalami;
                }
                else if (ingredient == "pepper")
                {
                    calories += calsInPepper;
                }
            }

            Console.WriteLine($"Total calories: {calories}");
        }
    }
}
