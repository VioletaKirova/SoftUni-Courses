using System;
using System.Collections.Generic;
using System.Linq;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] inputArgs = input
                    .Split(new char[] {' ', '-', '>'}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (inputArgs.Length == 2)
                {
                    string name = inputArgs[1];

                    if (users.ContainsKey(name))
                    {
                        users.Remove(name);
                    }
                }
                else
                {
                    string name = inputArgs[0];
                    string tag = inputArgs[1];
                    int likes = int.Parse(inputArgs[2]);

                    if (!users.ContainsKey(name))
                    {
                        users[name] = new Dictionary<string, int>();
                    }

                    if (!users[name].ContainsKey(tag))
                    {
                        users[name][tag] = 0;
                    }

                    users[name][tag] += likes;                    
                }

                input = Console.ReadLine();
            }

            foreach (var user in users.OrderByDescending(x => x.Value.Sum(y => y.Value)).ThenBy(x => x.Value.Keys.Count))
            {
                Console.WriteLine(user.Key);

                foreach (var tag in user.Value)
                {
                    Console.WriteLine($"- {tag.Key}: {tag.Value}");
                }
            }
        }
    }
}
