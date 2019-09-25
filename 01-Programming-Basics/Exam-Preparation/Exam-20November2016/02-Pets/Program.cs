using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            double days = double.Parse(Console.ReadLine());
            double kgFood = double.Parse(Console.ReadLine());
            double kgDogFoodPerDay = double.Parse(Console.ReadLine());
            double kgCatFoodPerDay = double.Parse(Console.ReadLine());
            double gramsTurtleFoodPerDay = double.Parse(Console.ReadLine());

            double kgTurtleFoodPerDay = gramsTurtleFoodPerDay / 1000;

            double neededFood = (kgDogFoodPerDay + kgCatFoodPerDay + kgTurtleFoodPerDay) * days;

            if (kgFood >= neededFood)
            {
                double extraFood = kgFood - neededFood;
                Console.WriteLine($"{Math.Floor(extraFood)} kilos of food left.");
            }
            else if (kgFood < neededFood)
            {
                double shortageOfFood = neededFood - kgFood;
                Console.WriteLine($"{Math.Ceiling(shortageOfFood)} more kilos of food are needed.");
            }
        }
    }
}
