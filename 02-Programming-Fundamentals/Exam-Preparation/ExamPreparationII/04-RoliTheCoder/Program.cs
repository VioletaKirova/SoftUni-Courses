using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_RoliTheCoder
{
    // 40/100
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var events = new Dictionary<int, Dictionary<string, List<string>>>();

            while (input != "Time for Code")
            {
                string[] data = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (data[1].First() != '#')
                {
                    input = Console.ReadLine();
                    continue;
                }

                for (int i = 2; i < data.Length; i++)
                {
                    if (data[i].First() != '@')
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                }

                int id = int.Parse(data[0]);
                string name = new string(data[1].Skip(1).ToArray());

                if (!events.ContainsKey(id))
                {
                    events.Add(id, new Dictionary<string, List<string>>());
                    events[id].Add(name, new List<string>());                    
                }
                else
                {
                    if (!events[id].ContainsKey(name))
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                }

                if (data.Length > 2)
                {
                    for (int i = 2; i < data.Length; i++)
                    {
                        events[id][name].Add(data[i]);
                    }
                }       
                
                input = Console.ReadLine();
            }

            foreach (var e in events.OrderByDescending(x => events[x.Key].Values.Count()).ThenBy(x => x.Key))
            {
                foreach (var value in e.Value)
                {
                    Console.WriteLine($"{value.Key} - {e.Value[value.Key].Count}");

                    foreach (var participant in e.Value[value.Key].OrderBy(x => x))
                    {
                        Console.WriteLine(participant);
                    }
                }   
            }

        }
    }
}