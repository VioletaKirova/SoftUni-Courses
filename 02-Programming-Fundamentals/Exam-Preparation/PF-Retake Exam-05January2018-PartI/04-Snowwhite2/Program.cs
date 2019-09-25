using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Snowwhite2
{
    // 60/100
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var dwarfsDict = new Dictionary<string, Dictionary<string, int>>();

            while (input != "Once upon a time")
            {
                string[] inputArr = input.Split(new string[] { " <:> " }, StringSplitOptions.RemoveEmptyEntries);

                string name = inputArr[0];
                string colour = inputArr[1];
                int physics = int.Parse(inputArr[2]);

                if (!dwarfsDict.ContainsKey(colour))
                {
                    dwarfsDict.Add(colour, new Dictionary<string, int>());
                    dwarfsDict[colour].Add(name, physics);
                }
                else if (!dwarfsDict[colour].ContainsKey(name))
                {
                    dwarfsDict[colour].Add(name, physics);
                }
                else if (dwarfsDict[colour][name] < physics)
                {
                    dwarfsDict[colour][name] = physics;
                }

                input = Console.ReadLine();
            }

            foreach (var color in dwarfsDict.OrderByDescending(x => x.Value.Values.Max()).ThenByDescending(x => x.Value.Count()))
            {
                var dwarfs = color.Value;

                foreach (var dwarf in dwarfs)
                {
                    Console.Write($"({color.Key}) ");
                    Console.WriteLine($"{dwarf.Key} <-> {dwarf.Value}");
                }
            }
        }
    }
}