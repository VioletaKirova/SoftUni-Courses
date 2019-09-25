using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_HornetAssault
{
    // 90/100
    class Program
    {
        static void Main(string[] args)
        {
            List<long> beehives = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
            List<long> hornets = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
            long hornetPower = hornets.Sum();

            for (int i = 0; i < beehives.Count; i++)
            {
                if (hornetPower > beehives[i])
                {
                    beehives.RemoveAt(i);
                    i--;

                    if (beehives.Sum() == 0)
                        break;
                }
                else if (hornetPower <= beehives[i])
                {
                    beehives[i] -= hornetPower;
                    hornets.RemoveAt(0);
                    hornetPower = hornets.Sum();

                    if (hornets.Sum() == 0)
                        break;
                }
            }

            if (beehives.Sum() > 0)
                Console.WriteLine(string.Join(" ", beehives.Where(x => x > 0)));
            else
                Console.WriteLine(string.Join(" ", hornets.Where(x => x > 0)));
        }
    }
}