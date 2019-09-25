using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_RoliTheCoder
{
    // 80/100
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var events = new Dictionary<int, string>();
            var data = new Dictionary<string, List<string>>();

            while (input != "Time for Code")
            {
                string[] inputArr = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (inputArr[1].First() != '#')
                {
                    input = Console.ReadLine();
                    continue;
                }

                for (int i = 2; i < inputArr.Length; i++)
                {
                    if (inputArr[i].First() != '@')
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                }

                int id = int.Parse(inputArr[0]);
                string name = new string(inputArr[1].Skip(1).ToArray());

                if (!events.ContainsKey(id))
                {
                    events.Add(id, name);
                    data.Add(name, new List<string>());
                }
                else
                {
                    if (!data.ContainsKey(name))
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                }

                if (inputArr.Length > 2)
                {
                    for (int i = 2; i < inputArr.Length; i++)
                    {
                        if (!data[name].Contains(inputArr[i]))
                        {
                            data[name].Add(inputArr[i]);
                        }                       
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var e in data.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{e.Key} - {e.Value.Count}");

                foreach (var p in e.Value.OrderBy(x => x))
                {
                    Console.WriteLine(p);
                }
            }

        }
    }
}