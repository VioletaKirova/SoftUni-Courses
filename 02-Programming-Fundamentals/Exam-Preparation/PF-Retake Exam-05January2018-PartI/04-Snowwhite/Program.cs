using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Snowwhite
{
    // 20/100
    class Program
    {      
        static void Main(string[] args)
        {
            var dwarfs = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();
            
            while (input != "Once upon a time")
            {
                string[] inputArr = input.Split(new string[] { " <:> " }, StringSplitOptions.RemoveEmptyEntries);
                string name = inputArr[0];
                string hatColour = inputArr[1];
                string physics = inputArr[2];

                if (!dwarfs.ContainsKey(name))
                {
                    dwarfs.Add(name, new List<string>());
                    dwarfs[name].Add(hatColour);
                    dwarfs[name].Add(physics);
                }
                else if (dwarfs.ContainsKey(name))
                {
                    if (!dwarfs[name].Contains(hatColour))
                    {
                        dwarfs.Add(name, new List<string>());
                        dwarfs[name].Add(hatColour);
                        dwarfs[name].Add(physics);
                    }
                    else if (dwarfs[name].Contains(hatColour))
                    {
                        if (int.Parse(dwarfs[name][1]) < int.Parse(physics))
                        {
                            dwarfs[name][1] = physics;
                        }
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var dwarf in dwarfs.OrderByDescending(x => int.Parse(x.Value[1])).OrderByDescending(x => x.Value[0]))
            {
                Console.WriteLine($"({dwarf.Value[0]}) {dwarf.Key} <-> {dwarf.Value[1]}");
            }
        }
    }
}