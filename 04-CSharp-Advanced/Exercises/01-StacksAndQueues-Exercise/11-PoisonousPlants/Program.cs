using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_PoisonousPlants
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] plants = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> plantQueue = new Queue<int>(plants);

            int daysCount = 0;
            bool noMoreDeadPlants = false;

            while (true)
            {
                bool deadPlantFound = false;

                for (int i = 0; i < plantQueue.Count; i++)
                {                 
                    int currentPlant = plantQueue.Dequeue();
                    int nextPlant = plantQueue.Peek();

                    if (currentPlant < nextPlant)
                    {
                        deadPlantFound = true;
                        plantQueue.Dequeue();
                    }

                    plantQueue.Enqueue(currentPlant);

                    if (i == plantQueue.Count - 1 && !deadPlantFound)
                    {
                        noMoreDeadPlants = true;
                        break;
                    }
                }

                if (noMoreDeadPlants)
                {
                    break;
                }

                daysCount++;
            }

            Console.WriteLine(daysCount);
        }
    }
}
