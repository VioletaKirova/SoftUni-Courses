using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_FruitShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double price = 0;

            bool weekDays = day == "Monday" || day == "Tuesday" || day == "Wednesday" 
                || day == "Thursday" || day == "Friday";
            bool weekend = day == "Saturday" || day == "Sunday";

            if (weekDays)
            {
                if (fruit == "banana") price = quantity * 2.5;
                else if (fruit == "apple") price = quantity * 1.2;
                else if (fruit == "orange") price = quantity * 0.85;
                else if (fruit == "grapefruit") price = quantity * 1.45;
                else if (fruit == "kiwi") price = quantity * 2.7;
                else if (fruit == "pineapple") price = quantity * 5.5;
                else if (fruit == "grapes") price = quantity * 3.85;
            }
            else if (weekend)
            {
                if (fruit == "banana") price = quantity * 2.7;
                else if (fruit == "apple") price = quantity * 1.25;
                else if (fruit == "orange") price = quantity * 0.9;
                else if (fruit == "grapefruit") price = quantity * 1.6;
                else if (fruit == "kiwi") price = quantity * 3;
                else if (fruit == "pineapple") price = quantity * 5.6;
                else if (fruit == "grapes") price = quantity * 4.2;
            }

            if (price != 0)
            {
                Console.WriteLine($"{price:f2}");
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
