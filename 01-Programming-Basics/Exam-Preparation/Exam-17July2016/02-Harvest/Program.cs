using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            int vineYardArea = int.Parse(Console.ReadLine());
            double grapePerSquareMeter = double.Parse(Console.ReadLine());
            int neededLitersWine = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double areaForHarvest = vineYardArea * 0.4;
            double harvestedGrape = areaForHarvest * grapePerSquareMeter;
            double litersMade = harvestedGrape / 2.5;

            double wineLeftOrNeeded = Math.Abs(neededLitersWine - litersMade);
            double litersPerWorker = wineLeftOrNeeded / workers;

            if (litersMade >= neededLitersWine)
            {
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(litersMade)} liters.");
                Console.WriteLine($"{Math.Ceiling(wineLeftOrNeeded)} liters left -> {Math.Ceiling(litersPerWorker)} liters per person.");
            }
            else
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(wineLeftOrNeeded)} liters wine needed.");
            }
        }
    }
}
