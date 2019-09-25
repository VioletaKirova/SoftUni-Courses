using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_AlcoholMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double whiskeyPerLiterCost = double.Parse(Console.ReadLine());
            double beerLiters = double.Parse(Console.ReadLine());
            double wineLiters = double.Parse(Console.ReadLine());
            double rakiaLiters = double.Parse(Console.ReadLine());
            double whiskeyLiters = double.Parse(Console.ReadLine());

            double rakiaPerLiterCost = whiskeyPerLiterCost * 0.5;
            double winePerLiterCost = rakiaPerLiterCost - rakiaPerLiterCost * 0.4;
            double beerPerLiterCost = rakiaPerLiterCost - rakiaPerLiterCost * 0.8;

            double price = whiskeyLiters * whiskeyPerLiterCost + beerLiters * beerPerLiterCost + wineLiters * winePerLiterCost + rakiaLiters * rakiaPerLiterCost;

            Console.WriteLine($"{price:f2}");
        }
    }
}
