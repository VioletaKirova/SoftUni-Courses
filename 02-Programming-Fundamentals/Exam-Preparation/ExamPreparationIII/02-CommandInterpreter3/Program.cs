using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_CommandInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> modifiedInput = new List<string>();

            string commandInput = Console.ReadLine();

            while (commandInput != "end")
            {
                string[] command = commandInput.Split(' ');

                if (command.Contains("reverse") || command.Contains("sort"))
                {
                    int start = int.Parse(command[2]);
                    int count = int.Parse(command[4]);

                    if (start < 0 || start > input.Count - 1 || (start + count) > input.Count || count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        commandInput = Console.ReadLine();
                        continue;
                    }

                    if (command[0] == "reverse")
                    {
                        input.Reverse(start, count);
                    }
                    else if (command[0] == "sort")
                    {
                        modifiedInput = input.Skip(start).Take(count).OrderBy(x => x).ToList();
                        input.RemoveRange(start, count);
                        input.InsertRange(start, modifiedInput);
                    }
                }
                else if (command.Contains("rollLeft") || command.Contains("rollRight"))
                {
                    int count = int.Parse(command[1]);
                    count %= input.Count;

                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        commandInput = Console.ReadLine();
                        continue;
                    }

                    if (command[0] == "rollLeft")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            input.Insert(input.Count, input[0]);
                            input.RemoveAt(0);
                        }
                    }
                    else if (command[0] == "rollRight")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            input.Insert(0, input[input.Count - 1]);
                            input.RemoveAt(input.Count - 1);
                        }
                    }
                }

                commandInput = Console.ReadLine();
            }

            Console.WriteLine("[" + string.Join(", ", input) + "]");
        }
    }
}