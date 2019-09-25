using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_CubicAssault
{
    class Program
    {
        static void Main(string[] args)
        {
            var regions = new Dictionary<string, Dictionary<string, long>>();

            string input = Console.ReadLine();

            while (input != "Count em all")
            {
                string[] inputArgs = input
                    .Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string regionName = inputArgs[0];
                string meteorType = inputArgs[1];
                int count = int.Parse(inputArgs[2]);

                if (!regions.ContainsKey(regionName))
                {
                    regions[regionName] = new Dictionary<string, long>();
                }

                if (!regions[regionName].ContainsKey(meteorType))
                {
                    regions[regionName][meteorType] = 0;
                }

                regions[regionName][meteorType] += count;

                if (regions[regionName][meteorType] >= 1000000 && meteorType != "Black")
                {
                    if (meteorType == "Green")
                    {
                        long redMeteors = regions[regionName][meteorType] / 1000000;
                        regions[regionName][meteorType] %= 1000000;

                        if (!regions[regionName].ContainsKey("Red"))
                        {
                            regions[regionName]["Red"] = 0;
                        }

                        regions[regionName]["Red"] += redMeteors;

                        if (regions[regionName]["Red"] >= 1000000)
                        {
                            long blackMeteors = regions[regionName]["Red"] / 1000000;
                            regions[regionName]["Red"] %= 1000000;

                            if (!regions[regionName].ContainsKey("Black"))
                            {
                                regions[regionName]["Black"] = 0;
                            }

                            regions[regionName]["Black"] += blackMeteors;
                        }
                    }
                    else if (meteorType == "Red")
                    {
                        long blackMeteors = regions[regionName][meteorType] / 1000000;
                        regions[regionName][meteorType] %= 1000000;

                        if (!regions[regionName].ContainsKey("Black"))
                        {
                            regions[regionName]["Black"] = 0;
                        }

                        regions[regionName]["Black"] += blackMeteors;
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var region in regions)
            {
                if (!region.Value.ContainsKey("Black"))
                {
                    region.Value["Black"] = 0L;
                }

                if (!region.Value.ContainsKey("Red"))
                {
                    region.Value["Red"] = 0L;
                }

                if (!region.Value.ContainsKey("Green"))
                {
                    region.Value["Green"] = 0L;
                }
            }

            foreach (var region in regions.OrderByDescending(x => x.Value["Black"]).ThenBy(x => x.Key.Length).ThenBy(x => x.Key))
            {
                Console.WriteLine(region.Key);

                foreach (var meteorType in region.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"-> {meteorType.Key} : {meteorType.Value}");
                }
            }
        }
    }
}
