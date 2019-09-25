using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_FlowerShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double magnolias = double.Parse(Console.ReadLine());
            double hyacinths = double.Parse(Console.ReadLine());
            double roses = double.Parse(Console.ReadLine());
            double cactuses = double.Parse(Console.ReadLine());
            double priceOfPresent = double.Parse(Console.ReadLine());

            double costOfMagnolias = magnolias * 3.25;
            double costOfHyacinths = hyacinths * 4;
            double costOfRoses = roses * 3.5;
            double costOfCactuses = cactuses * 8;

            double costOfAllFlowers = costOfMagnolias + costOfHyacinths + costOfRoses + costOfCactuses;
            double moneyForPresent = costOfAllFlowers - costOfAllFlowers * 0.05;

            if (moneyForPresent >= priceOfPresent)
            {
                double extraMoney = moneyForPresent - priceOfPresent;
                Console.WriteLine($"She is left with {Math.Floor(extraMoney)} leva.");
            }
            else if (moneyForPresent < priceOfPresent)
            {
                double neededMoney = priceOfPresent - moneyForPresent;
                Console.WriteLine($"She will have to borrow {Math.Ceiling(neededMoney)} leva.");
            }
        }
    }
}
