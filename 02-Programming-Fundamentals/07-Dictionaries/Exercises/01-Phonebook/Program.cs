using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();

            for (int i = 0; ; i++)
            {
                List<string> commands = Console.ReadLine().Split().ToList();

                if (commands[0] == "A")
                {
                    if (phoneBook.ContainsKey(commands[1]))
                        phoneBook[commands[1]] = commands[2];
                    else
                        phoneBook.Add(commands[1], commands[2]);
                }
                else if (commands[0] == "S")
                {
                    if (phoneBook.ContainsKey(commands[1]))
                        Console.WriteLine(commands[1] + " -> " + phoneBook[commands[1]]);
                    else
                        Console.WriteLine($"Contact {commands[1]} does not exist.");
                }
                else if (commands[0] == "END")
                {
                    break;
                }
            }
        }
    }
}