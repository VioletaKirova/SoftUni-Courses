using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = ReadInput();

            Dictionary<string, List<string>> vloggerFollowers = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> vloggerFollowings = new Dictionary<string, List<string>>();

            while (input[0] != "Statistics")
            {
                string command = input[1];

                if (command == "joined")
                {
                    string vloggerName = input[0];

                    if (!vloggerFollowers.ContainsKey(vloggerName))
                    {
                        vloggerFollowers[vloggerName] = new List<string>();
                        vloggerFollowings[vloggerName] = new List<string>();
                    }
                }
                else
                {
                    string follower = input[0];
                    string followedVlogger = input[2];

                    if (!vloggerFollowers.ContainsKey(follower) ||
                        !vloggerFollowers.ContainsKey(followedVlogger) ||
                        follower == followedVlogger)
                    {
                        input = ReadInput();

                        continue;
                    }

                    if (vloggerFollowers[followedVlogger].Contains(follower))
                    {
                        input = ReadInput();

                        continue;
                    }

                    vloggerFollowers[followedVlogger].Add(follower);
                    vloggerFollowings[follower].Add(followedVlogger);
                }

                input = ReadInput();
            }

            Dictionary<string, List<int>> vloggerStatistics = new Dictionary<string, List<int>>();

            foreach (var v in vloggerFollowers)
            {
                vloggerStatistics[v.Key] = new List<int>(2);

                vloggerStatistics[v.Key].Add(vloggerFollowers[v.Key].Count);
                vloggerStatistics[v.Key].Add(vloggerFollowings[v.Key].Count);
            }

            int totalVloggers = vloggerFollowers.Count();

            Console.WriteLine($"The V-Logger has a total of {totalVloggers} vloggers in its logs.");

            Dictionary<string, List<int>> orderedVloggerStatistics = vloggerStatistics
                .OrderByDescending(x => x.Value[0])
                .ThenBy(x => x.Value[1])
                .ToDictionary(x => x.Key, y=> y.Value);

            int count = 1;

            foreach (var vlogger in orderedVloggerStatistics)
            {
                if (count == 1)
                {
                    Console.WriteLine($"1. {vlogger.Key} : {vlogger.Value[0]} followers, {vlogger.Value[1]} following");

                    if (vloggerFollowers[vlogger.Key].Count > 0)
                    {
                        foreach (var follower in vloggerFollowers[vlogger.Key].OrderBy(x => x))
                        {
                            Console.WriteLine($"*  {follower}");
                        }
                    }

                    count++;
                }
                else
                {
                    Console.WriteLine($"{count}. {vlogger.Key} : {vlogger.Value[0]} followers, {vlogger.Value[1]} following");
                    count++;
                }
            }
        }

        private static string[] ReadInput()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
        }
    }
}
