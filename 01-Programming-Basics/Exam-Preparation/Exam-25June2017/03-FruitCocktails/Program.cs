using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_FruitCocktails
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine().ToLower();
            string size = Console.ReadLine().ToLower();
            int numberOfCocktails = int.Parse(Console.ReadLine());

            double price = -1.0;

            if (fruit == "watermelon")
            {
                if (size == "small")
                {
                    price = numberOfCocktails * (2 * 56);
                }
                else if (size == "big")
                {
                    price = numberOfCocktails * (5 * 28.7);
                }
            }
            else if (fruit == "mango")
            {
                if (size == "small")
                {
                    price = numberOfCocktails * (2 * 36.66);
                }
                else if (size == "big")
                {
                    price = numberOfCocktails * (5 * 19.6);
                }
            }
            else if (fruit == "pineapple")
            {
                if (size == "small")
                {
                    price = numberOfCocktails * (2 * 42.1);
                }
                else if (size == "big")
                {
                    price = numberOfCocktails * (5 * 24.8);
                }
            }
            else if (fruit == "raspberry")
            {
                if (size == "small")
                {
                    price = numberOfCocktails * (2 * 20);
                }
                else if (size == "big")
                {
                    price = numberOfCocktails * (5 * 15.2);
                }
            }

            if (price > 1000)
            {
                price -= price * 0.5;
            }
            else if (price >= 400 && price <= 1000)
            {
                price -= price * 0.15;
            }

            Console.WriteLine($"{price:f2} lv.");
        }
    }
}
