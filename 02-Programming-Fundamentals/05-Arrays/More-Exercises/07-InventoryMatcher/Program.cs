using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_InventoryMatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] products = Console.ReadLine().Split(' ').ToArray();
            long[] quantities = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            decimal[] prices = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();
            string productName = "";
            int place = 0;
            long quantity = 0;
            decimal price = 0.0m;

            for (int i = 0; ; i++)
            {
                productName = Console.ReadLine();

                if (productName == "done")
                {
                    break;
                }

                for (int j = 0; j < products.Length; j++)
                {
                    if (productName == products[j])
                    {
                        place = j;
                        break;
                    }
                }

                quantity = quantities[place];
                price = prices[place];
                Console.WriteLine($"{productName} costs: {price}; Available quantity: {quantity}");
            }
        }
    }
}