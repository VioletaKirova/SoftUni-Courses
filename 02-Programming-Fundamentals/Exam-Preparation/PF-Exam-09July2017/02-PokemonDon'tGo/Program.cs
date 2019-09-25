using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> distances = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int valueSum = 0;

            while (distances.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                int value = 0;

                if (index < 0)
                {
                    value = distances.First();
                    distances[0] = distances.Last();
                }
                else if (index > distances.Count - 1)
                {
                    value = distances.Last();
                    distances[distances.Count - 1] = distances.First();
                }
                else 
                {
                    value = distances[index];
                    distances.RemoveAt(index);                  
                }

                valueSum += value;

                for (int i = 0; i < distances.Count; i++)
                {
                    if (value >= distances[i])
                        distances[i] += value;
                    else if (value < distances[i])
                        distances[i] -= value;
                }
            }

            Console.WriteLine(valueSum);
        }
    }
}