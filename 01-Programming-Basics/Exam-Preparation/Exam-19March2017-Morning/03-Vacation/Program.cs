using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();

            string location = " ";
            string place = " ";
            double price = 0.0;

            if (budget <= 1000)
            {
                place = "Camp";

                if (season == "summer")
                {
                    location = "Alaska";
                    price = budget * 0.65;
                }
                else if (season == "winter")
                {
                    location = "Morocco";
                    price = budget * 0.45;
                }
            }
            else if (budget > 1000 && budget <= 3000)
            {
                place = "Hut";

                if (season == "summer")
                {
                    location = "Alaska";
                    price = budget * 0.8;
                }
                else if (season == "winter")
                {
                    location = "Morocco";
                    price = budget * 0.6;
                }
            }
            else if (budget > 3000)
            {
                place = "Hotel";

                if (season == "summer")
                {
                    location = "Alaska";
                }
                else if (season == "winter")
                {
                    location = "Morocco";
                }

                price = budget * 0.9;
            }

            Console.WriteLine($"{location} - {place} - {price:f2}");
        }
    }
}
