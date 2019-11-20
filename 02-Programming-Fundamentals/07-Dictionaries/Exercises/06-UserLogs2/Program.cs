using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_UserLogs2
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new SortedDictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();

            //example: IP=(IP.Address) message=(A&sample&message) user=(username)

            while (input != "end")
            {
                List<string> userLog = input
                    .Split(new char[] { '=', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string userName = userLog[5];
                string ip = userLog[1];

                if (!dict.ContainsKey(userName))
                {
                    dict[userName] = new Dictionary<string, int>();

                    if (!dict[userName].ContainsKey(ip))
                        dict[userName][ip] = 1;
                    else
                        dict[userName][ip]++;
                }
                else
                {
                    if (!dict[userName].ContainsKey(ip))
                        dict[userName][ip] = 1;
                    else
                        dict[userName][ip]++;
                }

                input = Console.ReadLine();
            }

            foreach (var user in dict)
            {
                Console.WriteLine($"{user.Key}:");

                foreach (var log in user.Value)
                {
                    if (log.Key != user.Value.Keys.Last())
                        Console.Write($"{log.Key} => {log.Value}, ");
                    else
                        Console.WriteLine($"{log.Key} => {log.Value}.");
                }
            }
        }
    }
}