using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_GreedyTimes
{
    // 90/100

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> typesAmount = new Dictionary<string, long>();
            Dictionary<string, Dictionary<string, long>> allItems = new Dictionary<string, Dictionary<string, long>>();

            long bagCapacity = long.Parse(Console.ReadLine());

            long totalAmountInBag = 0;

            string[] itemQuantityPairs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < itemQuantityPairs.Length - 1; i += 2)
            {
                string item = itemQuantityPairs[i];
                int quantity = int.Parse(itemQuantityPairs[i + 1]);

                if (item.Length == 3)
                {
                    if (!typesAmount.ContainsKey("Gem"))
                    {
                        continue;
                    }

                    if (!typesAmount.ContainsKey("Cash"))
                    {
                        if (typesAmount["Gem"] < quantity)
                        {
                            continue;
                        }

                        typesAmount["Cash"] = 0;
                        allItems["Cash"] = new Dictionary<string, long>();
                    }

                    if (typesAmount["Cash"] + quantity > typesAmount["Gem"])
                    {
                        continue;
                    }

                    typesAmount["Cash"] += quantity;

                    if (!allItems["Cash"].ContainsKey(item))
                    {
                        allItems["Cash"][item] = 0;
                    }

                    allItems["Cash"][item] += quantity;

                    totalAmountInBag += quantity;

                    if (totalAmountInBag >= bagCapacity)
                    {
                        break;
                    }

                }
                else if (item.ToLower().EndsWith("gem") && item.Length > 3)
                {
                    if (!typesAmount.ContainsKey("Gold"))
                    {
                        continue;
                    }

                    if (!typesAmount.ContainsKey("Gem"))
                    {
                        if (typesAmount["Gold"] < quantity)
                        {
                            continue;
                        }

                        typesAmount["Gem"] = 0;
                        allItems["Gem"] = new Dictionary<string, long>();
                    }

                    if (typesAmount["Gem"] + quantity > typesAmount["Gold"])
                    {
                        continue;
                    }

                    typesAmount["Gem"] += quantity;

                    if (!allItems["Gem"].ContainsKey(item))
                    {
                        allItems["Gem"][item] = 0;
                    }

                    allItems["Gem"][item] += quantity;

                    totalAmountInBag += quantity;

                    if (totalAmountInBag >= bagCapacity)
                    {
                        break;
                    }
                }
                else if (item.ToLower() == "gold")
                {
                    if (!typesAmount.ContainsKey("Gold"))
                    {
                        typesAmount["Gold"] = 0;
                        allItems["Gold"] = new Dictionary<string, long>();
                    }

                    typesAmount["Gold"] += quantity;

                    if (!allItems["Gold"].ContainsKey(item))
                    {
                        allItems["Gold"][item] = 0;
                    }

                    allItems["Gold"][item] += quantity;

                    totalAmountInBag += quantity;

                    if (totalAmountInBag >= bagCapacity)
                    {
                        break;
                    }
                }
            }

            foreach (var type in typesAmount.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"<{type.Key}> ${type.Value}");

                foreach (var item in allItems[type.Key].OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }
    }
}
