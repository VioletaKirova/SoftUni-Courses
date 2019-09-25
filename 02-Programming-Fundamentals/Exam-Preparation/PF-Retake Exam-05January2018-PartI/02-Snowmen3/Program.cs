using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Snowmen3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> snowmen = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            while (snowmen.Count > 1)
            {
                for (int i = 0; i < snowmen.Count; i++)
                {
                    int attacker = i;
                    int target = snowmen[i];

                    if (target > snowmen.Count - 1)
                    {
                        target %= snowmen.Count;
                    }

                    if (snowmen[i] == -1)
                    {
                        continue;
                    }

                    if (snowmen.Where(x => x != -1).Count() == 1)
                    {
                        return;
                    }
                 
                    int diff = Math.Abs(attacker - target);

                    if (attacker == target)
                    {
                        Console.WriteLine($"{attacker} performed harakiri");
                        snowmen[attacker] = -1;
                    }
                    else if (diff % 2 == 0)
                    {
                        Console.WriteLine($"{attacker} x {target} -> {attacker} wins");
                        snowmen[target] = -1;
                    }
                    else
                    {
                        Console.WriteLine($"{attacker} x {target} -> {target} wins");
                        snowmen[attacker] = -1;
                    }
                }

                snowmen = snowmen.Where(x => x != -1).ToList();
            }
        }
    }
}