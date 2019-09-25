using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> pumps = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] pump = Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                pumps.Enqueue(pump);
            }


            for (int i = 0; i < n; i++)
            {
                bool found = true;

                int fuel = 0;

                for (int j = 0; j < n; j++)
                {
                    int[] currentPump = pumps.Dequeue();

                    fuel += currentPump[0] - currentPump[1];

                    if (fuel < 0)
                    {
                        found = false;
                    }

                    pumps.Enqueue(currentPump);
                }

                if (found)
                {
                    Console.WriteLine(i);
                    break;
                }

                int[] startingPump = pumps.Dequeue();
                pumps.Enqueue(startingPump);
            }
        }
    }
}
