using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Snowwhite4
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var dwarfsByHatColour = new Dictionary<string, List<string>>();
            List<Dwarf> allDwarfs = new List<Dwarf>();

            while (input != "Once upon a time")
            {
                string[] inputParts = input.Split(new string[] { " <:> " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string dwarfName = inputParts[0];
                string dwarfHatColor = inputParts[1];
                int dwarfPhysics = int.Parse(inputParts[2]);

                if (!dwarfsByHatColour.ContainsKey(dwarfHatColor))
                {
                    dwarfsByHatColour.Add(dwarfHatColor, new List<string>());
                }

                if (!dwarfsByHatColour[dwarfHatColor].Contains(dwarfName))
                {
                    dwarfsByHatColour[dwarfHatColor].Add(dwarfName);

                    Dwarf newDwarf = new Dwarf();
                    newDwarf.Name = dwarfName;
                    newDwarf.HatColor = dwarfHatColor;
                    newDwarf.Physics = dwarfPhysics;

                    allDwarfs.Add(newDwarf);
                }
                else
                {
                    foreach (var d in allDwarfs)
                    {
                        if (d.Name == dwarfName)
                        {
                            if (d.Physics < dwarfPhysics)
                            {
                                d.Physics = dwarfPhysics;
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var dwarf in allDwarfs.OrderByDescending(x => x.Physics).ThenByDescending(x => dwarfsByHatColour[x.HatColor].Count()))
            {
                Console.WriteLine($"({dwarf.HatColor}) {dwarf.Name} <-> {dwarf.Physics}");
            }
        }

        class Dwarf
        {
            public string Name { get; set; }
            public string HatColor { get; set; }
            public int Physics { get; set; }
        }
    }
}