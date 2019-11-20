using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_UpgradedMatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] products = Console.ReadLine().Split(' ').ToArray();
            long[] quantities = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            decimal[] prices = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();
            string[] prodAndNeededQuantity = new string[2];
            int index = 0;
            long quantity = 0;
            decimal price = 0.0m;
            decimal totalPrice = 0.0m;
            long neededQuantity = 0;

            for (int i = 0; ; i++)
            {
                prodAndNeededQuantity = Console.ReadLine().Split(' ').ToArray();

                if (prodAndNeededQuantity[0] == "done")
                {
                    break;
                }
                for (int j = 0; j < products.Length; j++)
                {
                    if (prodAndNeededQuantity[0] == products[j])
                    {
                        index = j;
                    }                
                }

                price = prices[index];
                neededQuantity = long.Parse(prodAndNeededQuantity[1]);

                for (int k = 0; k < quantities.Length; k++)
                {
                    if (k == index)
                    {
                        quantity = quantities[k];
                        break;
                    }
                }

                if (neededQuantity <= quantity)
                {
                    quantities[index] -= neededQuantity;
                    totalPrice = neededQuantity * price;
                    Console.WriteLine($"{prodAndNeededQuantity[0]} x {neededQuantity} costs {totalPrice:f2}");
                }
                else
                {
                    Console.WriteLine($"We do not have enough {prodAndNeededQuantity[0]}");
                }

                quantity = 0;
            }
        }
    }
}