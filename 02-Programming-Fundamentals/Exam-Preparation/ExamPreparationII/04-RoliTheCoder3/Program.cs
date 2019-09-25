using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_RoliTheCoder
{
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
                List<string> participants = new List<string>();

                if (inputArr.Length > 2)
                {
                    for (int i = 2; i < inputArr.Length; i++)
                    {
                        participants.Add(inputArr[i]);
                    }
                }

                if (!events.ContainsKey(id))
                {
                    events.Add(id, name);
                    data.Add(name, participants);
                }
                else if (events[id] == name)
                {
                    data[name].AddRange(participants);
                }
               
                input = Console.ReadLine();
            }

            foreach (var e in data.OrderByDescending(x => x.Value.Distinct().Count()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{e.Key} - {e.Value.Distinct().Count()}");

                foreach (var p in e.Value.OrderBy(x => x).Distinct())
                {
                    Console.WriteLine(p);
                }
            }
        }
    }
}