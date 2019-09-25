using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int i = 0; ; i++)
            {
                string resource = Console.ReadLine();

                if (resource == "stop")
                    break;

                int quantity = int.Parse(Console.ReadLine());

                if (!dict.ContainsKey(resource))
                    dict[resource] = quantity;
                else
                    dict[resource] += quantity;
            }

            foreach (var r in dict)
            {
                Console.WriteLine(r.Key + " -> " + r.Value);
            }
        }
    }
}