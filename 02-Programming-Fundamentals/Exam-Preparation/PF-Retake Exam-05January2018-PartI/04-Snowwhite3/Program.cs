using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Snowwhite2
{
    class Program
    {
        class Dwarf
        {
            public string Name { get; set; }
            public string HatColour { get; set; }
            public int Physics { get; set; }
        }

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

            var allDwarfs = new List<Dwarf>();

            foreach (var color in dwarfsDict)
            {
                foreach (var dwarf in color.Value)
                {
                    Dwarf newDwarf = new Dwarf();
                    newDwarf.Name = dwarf.Key;
                    newDwarf.HatColour = color.Key;
                    newDwarf.Physics = dwarf.Value;
                    allDwarfs.Add(newDwarf);
                }
            }

            foreach (var dwarf in allDwarfs.OrderByDescending(x => x.Physics).ThenByDescending(x => x.HatColour.Count()))
            {
                Console.WriteLine($"({dwarf.HatColour}) {dwarf.Name} <-> {dwarf.Physics}");
            }
        }
    }
}