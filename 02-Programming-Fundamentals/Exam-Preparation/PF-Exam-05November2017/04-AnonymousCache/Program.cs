using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_AnonymousCache
{
    // 80/100
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var dataSets = new Dictionary<string, Dictionary<string, int>>();
            var cache = new Dictionary<string, Dictionary<string, int>>();

            while (input != "thetinggoesskrra")
            {
                List<string> inputList = input.Split(new char[] { ' ', '-', '>', '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                if (inputList.Count == 1)
                {
                    string set = inputList[0].Trim();

                    if (!dataSets.ContainsKey(set))
                    {
                        dataSets.Add(set, new Dictionary<string, int>());
                    }

                    if (cache.ContainsKey(set))
                    {
                        foreach (var s in cache[set])
                        {
                            dataSets[set].Add(s.Key, s.Value);
                        }

                        cache.Remove(set);
                    }
                }
                else
                {
                    string key = inputList[0].Trim();
                    int size = int.Parse(inputList[1]);
                    string set = inputList[2].Trim();

                    if (dataSets.ContainsKey(set))
                    {
                        dataSets[set].Add(key, size);
                    }
                    else if (!dataSets.ContainsKey(set))
                    {
                        if (!cache.ContainsKey(set))
                        {
                            cache.Add(set, new Dictionary<string, int>());
                            cache[set].Add(key, size);
                        }
                        else
                        {
                            cache[set].Add(key, size);
                        }
                    }                   
                }

                input = Console.ReadLine();
            }

            if (dataSets.Count > 0)
            {
                List<long> sizes = new List<long>();

                foreach (var set in dataSets)
                {
                    long size = set.Value.Values.Sum();
                    sizes.Add(size);
                }

                sizes = sizes.OrderBy(x => -x).ToList();
                long biggestSize = sizes.First();

                foreach (var set in dataSets)
                {
                    if (biggestSize == set.Value.Values.Sum())
                    {
                        Console.WriteLine($"Data Set: {set.Key}, Total Size: {biggestSize}");

                        foreach (var value in set.Value)
                        {
                            Console.WriteLine($"$.{value.Key}");
                        }
                    }
                }
            }           
        }
    }
}