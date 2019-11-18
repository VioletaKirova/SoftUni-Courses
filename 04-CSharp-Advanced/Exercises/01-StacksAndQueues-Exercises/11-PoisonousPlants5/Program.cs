using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_PoisonousPlants5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> plants = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> deadPlantsIndexes = new List<int>();

            int days = 0;

            while (true)
            {
                for (int i = 0; i < plants.Count - 1; i++)
                {
                    int currentPlant = plants[i];
                    int nextPlant = plants[i + 1];

                    if (currentPlant < nextPlant)
                    {
                        deadPlantsIndexes.Add(i + 1);
                    }
                }

                if (deadPlantsIndexes.Count == 0)
                {
                    break;
                }

                int indexCounter = 0;

                for (int i = 0; i < deadPlantsIndexes.Count; i++)
                {
                    plants.RemoveAt(deadPlantsIndexes[i] - indexCounter);

                    indexCounter++;
                }

                days++;

                deadPlantsIndexes.Clear();
            }

            Console.WriteLine(days);
        }
    }
}
