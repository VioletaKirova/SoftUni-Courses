using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_CarToGo
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();

            string carClass = "";
            string car = "";

            double cost = 0.0;

            if (budget <= 100)
            {
                carClass = "Economy class";

                if (season == "summer")
                {
                    car = "Cabrio";
                    cost = budget * 0.35;
                }
                else if (season == "winter")
                {
                    car = "Jeep";
                    cost = budget * 0.65;
                }
            }
            else if (budget > 100 && budget <= 500)
            {
                carClass = "Compact class";

                if (season == "summer")
                {
                    car = "Cabrio";
                    cost = budget * 0.45;
                }
                else if (season == "winter")
                {
                    car = "Jeep";
                    cost = budget * 0.8;
                }
            }
            else if (budget > 500)
            {
                carClass = "Luxury class";

                car = "Jeep";
                cost = budget * 0.9;
            }

            Console.WriteLine($"{carClass}");
            Console.WriteLine($"{car} - {cost:f2}");
        }
    }
}
