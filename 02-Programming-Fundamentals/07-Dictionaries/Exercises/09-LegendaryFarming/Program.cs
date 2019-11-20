using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, int>();
            dict.Add("shards", 0);
            dict.Add("fragments", 0);
            dict.Add("motes", 0);

            bool obtained = false;
            string legendaryItem = "";

            for (int i = 0; ; i++)
            {
                if (obtained)
                    break;

                List<string> input = Console.ReadLine().ToLower().Split(' ').ToList();
                
                for (int j = 1; j < input.Count; j += 2)
                {
                    string material = input[j];
                    int quantity = int.Parse(input[j - 1]);

                    if (!dict.ContainsKey(material))
                        dict[material] = 0;

                    dict[material] += quantity;

                    if (dict[material] >= 250)
                    {
                        if (material == "shards")
                        {
                            dict[material] -= 250;
                            obtained = true;
                            legendaryItem = "Shadowmourne";
                            break;
                        }
                        else if (material == "fragments")
                        {
                            dict[material] -= 250;
                            obtained = true;
                            legendaryItem = "Valanyr";
                            break;
                        }
                        else if (material == "motes")
                        {
                            dict[material] -= 250;
                            obtained = true;
                            legendaryItem = "Dragonwrath";
                            break;
                        }
                    }
                }                
            }

            var rareItems = dict
                .Take(3)
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToList();

            var junkItems = dict
                .Skip(3)
                .OrderBy(x => x.Key)
                .ToList();

            Console.WriteLine($"{legendaryItem} obtained!");

            foreach (var rareItem in rareItems)
            {
                Console.WriteLine($"{rareItem.Key}: {rareItem.Value}");
            }

            foreach (var item in junkItems)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}