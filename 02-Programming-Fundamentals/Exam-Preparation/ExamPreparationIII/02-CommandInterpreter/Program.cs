using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_CommandInterpreter
{
    // 35/100
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string commandInput = Console.ReadLine();

            while (commandInput != "end")
            {
                string[] command = commandInput.Split(' ');

                if (command.Contains("reverse") || command.Contains("sort"))
                {
                    int start = int.Parse(command[2]);
                    int count = int.Parse(command[4]);

                    if (start < 0 || count < 0 
                        || start > input.Length - 1 || count > input.Length - 1 
                        || start + count < 0 || start + count > input.Length - 1)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        commandInput = Console.ReadLine();
                        continue;
                    }

                    if (command[0] == "reverse")
                    {
                        string[] reversed = input.Skip(start).Take(count).Reverse().ToArray();
                        int index = 0;

                        for (int i = start; i <= count + 1; i++)
                        {
                            input[i] = reversed[index];
                            index++;
                        }
                    }
                    else if (command[0] == "sort")
                    {
                        string[] sorted = input.Skip(start).Take(count).OrderBy(x => x).ToArray();
                        int index = 0;

                        for (int i = start; i < count; i++)
                        {
                            input[i] = sorted[index];
                            index++;
                        }
                    }
                }
                else if (command.Contains("rollLeft") || command.Contains("rollRight"))
                {
                    int count = int.Parse(command[1]);

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
                            string firstElement = input[0];

                            for (int j = 0; j < input.Length - 1; j++)
                            {
                                input[j] = input[j + 1];
                            }

                            input[input.Length - 1] = firstElement;
                        }
                    }
                    else if (command[0] == "rollRight")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            string lastElement = input[input.Length - 1];

                            for (int j = input.Length - 2; j > 0; j--)
                            {
                                input[j] = input[j + 1];
                            }

                            input[0] = lastElement;
                        }                        
                    }
                }
                commandInput = Console.ReadLine();
            }
            Console.WriteLine("[" + string.Join(", ", input) + "]");
        }
    }
}