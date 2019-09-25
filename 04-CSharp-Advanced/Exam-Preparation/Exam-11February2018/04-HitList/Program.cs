using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_HitList
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, string>> peopleInfos = new Dictionary<string, Dictionary<string, string>>();

            int targetInfoIndex = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "end transmissions")
            {
                string[] inputParts = input.Split('=', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = inputParts[0];
                string info = inputParts[1];

                string[] infoParts = info.Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (!peopleInfos.ContainsKey(name))
                {
                    peopleInfos[name] = new Dictionary<string, string>();
                }

                foreach (var item in infoParts)
                {
                    string[] kvp = item.Split(':', StringSplitOptions.RemoveEmptyEntries).ToArray();

                    string key = kvp[0];
                    string value = kvp[1];

                    peopleInfos[name][key] = value;
                }

                input = Console.ReadLine();
            }

            string[] personToKill = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            string personToKillName = personToKill[1];

            Console.WriteLine($"Info on {personToKillName}:");

            foreach (var kvp in peopleInfos[personToKillName].OrderBy(x => x.Key))
            {
                Console.WriteLine($"---{kvp.Key}: {kvp.Value}");
            }

            int infoIndex = peopleInfos[personToKillName].Sum(x => x.Key.Length) + peopleInfos[personToKillName].Sum(x => x.Value.Length);

            Console.WriteLine($"Info index: {infoIndex}");

            if (infoIndex >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetInfoIndex - infoIndex} more info.");
            }
        }
    }
}
