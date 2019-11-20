using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_FixEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, string>();

            for (int i = 0; ; i++)
            {
                string name = Console.ReadLine();

                if (name == "stop")
                    break;

                string email = Console.ReadLine();

                char[] emailArr = email.ToArray();
                char[] lastTwoChars = emailArr.Reverse().Take(2).Reverse().ToArray();
                string str = string.Join("", lastTwoChars);

                if (str != "us" && str != "uk")
                {
                    dict[name] = email;
                }
            }

            foreach (var p in dict)
            {
                Console.WriteLine($"{p.Key} -> {p.Value}");
            }
        }
    }
}