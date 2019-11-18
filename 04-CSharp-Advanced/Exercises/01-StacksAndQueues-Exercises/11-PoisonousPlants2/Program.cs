using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_PoisonousPlants2
{
    // 77/100

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] plants = Console.ReadLine()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

            int days = 0;

            while (true)
            {
                bool deadPlants = false;

                Queue<int> survivingPlants = new Queue<int>();

                survivingPlants.Enqueue(plants[0]);

                for (int i = 1; i < plants.Length; i++)
                {
                    if (plants[i - 1] >= plants[i])
                    {
                        survivingPlants.Enqueue(plants[i]);
                    }
                    else
                    {
                        deadPlants = true;
                    }
                }

                if (!deadPlants)
                {
                    break;
                }

                days++;

                plants = survivingPlants.ToArray();
            }

            Console.WriteLine(days);
        }
    }
}
