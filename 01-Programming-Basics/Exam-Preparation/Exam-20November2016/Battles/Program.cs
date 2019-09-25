using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battles
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstPokemons = int.Parse(Console.ReadLine());
            int secondPokemons = int.Parse(Console.ReadLine());
            int maxBattles = int.Parse(Console.ReadLine());
            int battles = 0;

            for (int j = 1; j <= firstPokemons; j++)
            {
                for (int l = 1; l <= secondPokemons; l++)
                {
                    battles++;

                    if (battles > maxBattles)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write($"({j} <-> {l}) ");

                    }
                }
            }
        }
    }
}
