using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_LogsAggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new SortedDictionary<string, SortedDictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ').ToList();
                //example: 192.168.0.11 peter 33

                string ip = input[0];
                string user = input[1];
                int duration = int.Parse(input[2]);

                if (!dict.ContainsKey(user))
                    dict.Add(user, new SortedDictionary<string, int>());

                if (!dict[user].ContainsKey(ip))
                    dict[user].Add(ip, duration);
                else
                    dict[user][ip] += duration;
            }

            foreach (var user in dict)
            {
                var totalDurationOfUser = dict[user.Key].Values.Sum();
                var listOfIps = user.Value.Keys.ToList();
                Console.WriteLine($"{user.Key}: {totalDurationOfUser} [{string.Join(", ", listOfIps)}]");
            }
        }
    }
}