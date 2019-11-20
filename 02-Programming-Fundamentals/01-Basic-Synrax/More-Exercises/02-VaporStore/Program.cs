using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_VaporStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var balance = double.Parse(Console.ReadLine());
            var totalSpent = 0.0;
            bool gameTime = false;

            for (int i = 0; ; i++)
            {
                var game = Console.ReadLine();
                var gamePrice = 0.0;

                switch (game)
                {
                    case "OutFall 4": gamePrice = 39.99; break;
                    case "CS: OG": gamePrice = 15.99; break;
                    case "Zplinter Zell": gamePrice = 19.99; break;
                    case "Honored 2": gamePrice = 59.99; break;
                    case "RoverWatch": gamePrice = 29.99; break;
                    case "RoverWatch Origins Edition": gamePrice = 39.99; break;
                    case "Game Time": gameTime = true; break;
                    default: Console.WriteLine("Not Found"); break;
                }

                if (gameTime)
                {
                    break;
                }

                if (balance - gamePrice < 0)
                {
                    Console.WriteLine("Too Expensive");
                }
                else if (gamePrice != 0.0)
                {
                    balance -= gamePrice;
                    totalSpent += gamePrice;
                    Console.WriteLine($"Bought {game}");
                }

                if (balance == 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }
            }

            if (gameTime)
            {
                Console.WriteLine($"Total spent: ${totalSpent:f2}. Remaining: ${balance:f2}");
            }
        }
    }
}
