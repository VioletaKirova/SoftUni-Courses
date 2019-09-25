using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_EnduranceRally
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] drivers = Console.ReadLine().Split(' ').ToArray();
            decimal[] zones = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();
            int[] indexes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            decimal fuel = 0;
            int reachedZones = 0;

            for (int i = 0; i < drivers.Length; i++)
            {
                reachedZones = 0;
                fuel = (int)(drivers[i].First());

                for (int j = 0; j < zones.Length; j++)
                {
                    if (indexes.Contains(j))
                    {
                        fuel += zones[j];
                        reachedZones++;
                    }
                    else
                    {
                        fuel -= zones[j];

                        if (fuel > 0)
                            reachedZones++;
                        else
                            break;
                    }
                }

                if (fuel > 0)
                    Console.WriteLine($"{drivers[i]} - fuel left {fuel:f2}");
                else
                    Console.WriteLine($"{drivers[i]} - reached {reachedZones}");
            }

        }
    }
}