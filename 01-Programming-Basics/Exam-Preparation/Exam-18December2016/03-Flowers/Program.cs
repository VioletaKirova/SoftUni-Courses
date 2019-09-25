using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            int chrysanthemums = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int tulips = int.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();
            string holiday = Console.ReadLine().ToLower();

            double allFlowers = chrysanthemums + roses + tulips;
            double chrysanthemumsPrice = 0.0;
            double rosesPrice = 0.0;
            double tulipsPrice = 0.0;

            double bouquetPrice = 0.0;

            if (season == "spring" || season == "summer")
            {
                chrysanthemumsPrice = chrysanthemums * 2.0;
                rosesPrice = roses * 4.1;
                tulipsPrice = tulips * 2.5;
            }
            else if (season == "autumn" || season == "winter")
            {
                chrysanthemumsPrice = chrysanthemums * 3.75;
                rosesPrice = roses * 4.5;
                tulipsPrice = tulips * 4.15;
            }

            bouquetPrice = chrysanthemumsPrice + rosesPrice + tulipsPrice;

            if (holiday == "y")
            {
                bouquetPrice += bouquetPrice * 0.15;
            }

            if (season == "spring" && tulips > 7)
            {
                bouquetPrice -= bouquetPrice * 0.05;
            }
            else if (season == "winter" && roses >= 10)
            {
                bouquetPrice -= bouquetPrice * 0.1;
            }

            if (allFlowers > 20)
            {
                bouquetPrice -= bouquetPrice * 0.2;
            }

            double finalBouquetPrice = bouquetPrice + 2;

            Console.WriteLine($"{finalBouquetPrice:f2}");
        }
    }
}
