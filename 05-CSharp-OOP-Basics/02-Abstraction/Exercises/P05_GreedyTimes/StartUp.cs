using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            Bag bag = new Bag(bagCapacity);

            string[] items = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < items.Length; i += 2)
            {
                string item = items[i];
                long value = long.Parse(items[i + 1]);

                string type = string.Empty;

                if (item.Length == 3)
                {
                    type = "Cash";
                }
                else if (item.ToLower().EndsWith("gem"))
                {
                    type = "Gem";
                }
                else if (item.ToLower() == "gold")
                {
                    type = "Gold";
                }

                if (type == "")
                {
                    continue;
                }
                else if (bagCapacity < bag.Types.Values.Select(x => x.Values.Sum()).Sum() + value)
                {
                    continue;
                }

                switch (type)
                {
                    case "Gem":
                        if (!bag.Types.ContainsKey(type))
                        {
                            if (bag.Types.ContainsKey("Gold"))
                            {
                                if (value > bag.Types["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag.Types[type].Values.Sum() + value > bag.Types["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!bag.Types.ContainsKey(type))
                        {
                            if (bag.Types.ContainsKey("Gem"))
                            {
                                if (value > bag.Types["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag.Types[type].Values.Sum() + value > bag.Types["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                if (!bag.Types.ContainsKey(type))
                {
                    bag.Types[type] = new Dictionary<string, long>();
                }

                if (!bag.Types[type].ContainsKey(item))
                {
                    bag.Types[type][item] = 0;
                }

                bag.Types[type][item] += value;
            }

            foreach (var type in bag.Types)
            {
                Console.WriteLine($"<{type.Key}> ${type.Value.Values.Sum()}");

                foreach (var item in type.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }
    }
}