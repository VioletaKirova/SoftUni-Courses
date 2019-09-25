using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_CakeIngredients
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = 0;

            for (int i = 0; ; i++)
            {
                var ingredient = Console.ReadLine();

                if (ingredient != "Bake!")
                {
                    count++;
                    Console.WriteLine($"Adding ingredient {ingredient}.");
                }
                else
                {
                    Console.WriteLine($"Preparing cake with {count} ingredients.");
                    break;
                }
            }
        }
    }
}
