using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_NeighbourWars
{
    class Program
    {
        static void Main(string[] args)
        {
            var peshoDamage = int.Parse(Console.ReadLine());
            var goshoDamage = int.Parse(Console.ReadLine());

            var peshoName = "Pesho";
            var goshoName = "Gosho";

            var peshoAttack = "Roundhouse kick";
            var goshoAttack = "Thunderous fist";

            var peshoHealth = 100;
            var goshoHealth = 100;

            bool peshoWins = false;
            bool goshoWins = false;

            var rounds = 0;

            for (int i = 1; ; i++)
            {
                rounds++;

                if (i % 2 != 0)
                {
                    goshoHealth -= peshoDamage;
                }
                else
                {
                    peshoHealth -= goshoDamage;
                }

                if (goshoHealth <= 0 || peshoHealth <= 0)
                {
                    if (goshoHealth <= 0)
                    {
                        peshoWins = true;
                    }
                    else
                    {
                        goshoWins = true;
                    }
                    break;
                }

                if (i % 2 != 0)
                {
                    Console.WriteLine($"{peshoName} used {peshoAttack} and reduced {goshoName} to {goshoHealth} health.");
                }
                else
                {
                    Console.WriteLine($"{goshoName} used {goshoAttack} and reduced {peshoName} to {peshoHealth} health.");
                }

                if (i % 3 == 0)
                {
                    goshoHealth += 10;
                    peshoHealth += 10;
                }                
            }

            if (peshoWins)
            {
                Console.WriteLine($"{peshoName} won in {rounds}th round.");
            }
            else if (goshoWins)
            {
                Console.WriteLine($"{goshoName} won in {rounds}th round.");
            }
        }
    }
}
