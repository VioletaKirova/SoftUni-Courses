using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_ArrayManipulator
{
    // 50/100
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] commandData = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (commandData[0] == "exchange")
                {
                    int index = int.Parse(commandData[1]);
                    if (index > input.Count - 1)
                    {
                        Console.WriteLine("Invalid index");
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        int[] firstArr = input.Take(index + 1).ToArray();
                        int[] secondArr = input.Skip(index + 1).Take(input.Count - index + 1).ToArray();
                        input = new List<int>();
                        input.InsertRange(0, secondArr);
                        input.InsertRange(secondArr.Length, firstArr);
                    }
                }
                else if (commandData[0] == "max")
                {
                    int max = int.MinValue;
                    int index = 0;
                    if (commandData.Contains("even"))
                    {                                          
                        for (int i = 0; i < input.Count; i++)
                        {
                            if (input[i] % 2 == 0 && input[i] >= max)
                            {
                                index = i;
                                max = input[i];
                            }
                        }
                    }
                    else if (commandData.Contains("odd"))
                    {
                        for (int i = 0; i < input.Count; i++)
                        {
                            if (input[i] % 2 == 1 && input[i] >= max)
                            {
                                index = i;
                                max = input[i];
                            }
                        }
                    }

                    if (max == int.MinValue)
                        Console.WriteLine("No matches");
                    else
                        Console.WriteLine(index);
                }
                else if (commandData[0] == "min")
                {
                    int min = int.MaxValue;
                    int index = 0;
                    if (commandData.Contains("even"))
                    {                   
                        for (int i = 0; i < input.Count; i++)
                        {
                            if (input[i] % 2 == 0 && input[i] <= min)
                            {
                                index = i;
                                min = input[i];
                            }
                        }
                    }
                    else if (commandData.Contains("odd"))
                    {
                        for (int i = 0; i < input.Count; i++)
                        {
                            if (input[i] % 2 == 1 && input[i] <= min)
                            {
                                index = i;
                                min = input[i];
                            }
                        }
                    }

                    if (min == int.MaxValue)
                        Console.WriteLine("No matches");
                    else
                        Console.WriteLine(index);
                }
                else if (commandData[0] == "first" || commandData[0] == "last")
                {
                    int count = int.Parse(commandData[1]);

                    if (count > input.Count)
                    {
                        Console.WriteLine("Invalid count");
                        command = Console.ReadLine();
                        continue;
                    }

                    List<int> evenOrOdd = new List<int>();
                    int countNums = 0;

                    if (commandData[0] == "first" && commandData[2] == "even")
                    {
                        for (int i = 0; i < input.Count; i++)
                        {
                            if (input[i] % 2 == 0)
                            {
                                evenOrOdd.Add(input[i]);
                                countNums++;
                            }
                            if (countNums == count)
                                break;
                        }
                    }
                    else if (commandData[0] == "first" && commandData[2] == "odd")
                    {
                        for (int i = 0; i < input.Count; i++)
                        {
                            if (input[i] % 2 == 1)
                            {
                                evenOrOdd.Add(input[i]);
                                countNums++;
                            }
                            if (countNums == count)
                                break;
                        }
                    }
                    else if (commandData[0] == "last" && commandData[2] == "even")
                    {
                        for (int i = input.Count - 1; i >= 0; i--)
                        {
                            if (input[i] % 2 == 0)
                            {
                                evenOrOdd.Add(input[i]);
                                countNums++;
                            }
                            if (countNums == count)
                                break;
                        }
                    }
                    else if (commandData[0] == "last" && commandData[2] == "odd")
                    {                      
                        for (int i = input.Count - 1; i >= 0; i--)
                        {
                            if (input[i] % 2 == 1)
                            {
                                evenOrOdd.Add(input[i]);
                                countNums++;
                            }
                            if (countNums == count)
                                break;
                        }
                    }
                    Console.WriteLine($"[{string.Join(", ", evenOrOdd)}]");
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"[{string.Join(", ", input)}]");
        }
    }
}