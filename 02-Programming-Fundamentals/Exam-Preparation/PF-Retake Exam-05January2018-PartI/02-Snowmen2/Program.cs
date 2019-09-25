using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Snowmen2
{
    // 60/100
    class Program
    {
        static void Main(string[] args)
        {
            List<int> allSnowmen = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> losers = new List<int>();
            List<int> winners = new List<int>();

            while (allSnowmen.Count > 1)
            {
                losers = new List<int>();
                winners = new List<int>();

                int allSnowmenCount = allSnowmen.Count;

                for (int i = 0; i < allSnowmen.Count; i++)
                {
                    int value = allSnowmen[i];

                    if (losers.Contains(i))
                        continue;
                    else
                    {
                        if (allSnowmen[i] > allSnowmen.Count)
                            allSnowmen[i] %= allSnowmen.Count;

                        if (i == allSnowmen[i])
                        {
                            Console.WriteLine($"{i} performed harakiri");
                            losers.Add(i);
                            allSnowmenCount--;
                            continue;
                        }

                        int diff = Math.Abs(i - allSnowmen[i]);

                        if (diff % 2 == 0)
                        {
                            Console.WriteLine($"{i} x {allSnowmen[i]} -> {i} wins");
                            losers.Add(allSnowmen[i]);
                            winners.Add(value);
                        }
                        else if (diff % 2 == 1)
                        {
                            Console.WriteLine($"{i} x {allSnowmen[i]} -> {allSnowmen[i]} wins");
                            losers.Add(i);
                            allSnowmenCount--;
                        }

                        if (allSnowmenCount == 1)
                        {
                            break;
                        }
                    }

                }

                allSnowmen = new List<int>();

                foreach (var snowman in winners)
                {
                    allSnowmen.Add(snowman);
                }
            }
        }
    }
}