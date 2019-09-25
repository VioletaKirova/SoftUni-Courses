using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_TrainingHallEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            var startingBudget = double.Parse(Console.ReadLine());
            var items = int.Parse(Console.ReadLine());

            var subtotal = 0.0;
            var moneyLeftOrNeeded = 0.0;
            var budget = startingBudget;
            
            for (int i = 1; i <= items; i++)
            {
                var name = Console.ReadLine();
                var price = double.Parse(Console.ReadLine());
                var count = int.Parse(Console.ReadLine());

                if (count > 1)
                    Console.WriteLine($"Adding {count} {name}s to cart.");
                else
                    Console.WriteLine($"Adding {count} {name} to cart.");

                budget -= (price * count);
                subtotal += (price * count);
            }

            moneyLeftOrNeeded = Math.Abs(budget);

            if (subtotal <= startingBudget)
            {
                Console.WriteLine($"Subtotal: ${subtotal:f2}");
                Console.WriteLine($"Money left: ${moneyLeftOrNeeded:f2}");
            }
            else
            {
                Console.WriteLine($"Subtotal: ${subtotal:f2}");
                Console.WriteLine($"Not enough. We need ${moneyLeftOrNeeded:f2} more.");
            }
        }
    }
}
