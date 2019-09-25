using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_CommandInterpreter2
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataToChange = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> theNewStr = new List<string>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] inputTokens = input.Split(' ').ToArray();

                if (inputTokens[0] == "reverse")
                {
                    int start = int.Parse(inputTokens[2]);
                    int count = int.Parse(inputTokens[4]);

                    if (start < 0 || start >= dataToChange.Count || (start + count) > dataToChange.Count || count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                    else
                    {
                        dataToChange.Reverse(start, count);
                    }

                    //Console.WriteLine(string.Join(" ",dataToChange));
                }
                else if (inputTokens[0] == "sort")
                {
                    int start = int.Parse(inputTokens[2]);
                    int count = int.Parse(inputTokens[4]);

                    if (start < 0 || start >= dataToChange.Count || (start + count) > dataToChange.Count || count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                    else
                    {
                        theNewStr = dataToChange.Skip(start).Take(count).OrderBy(str => str).ToList();
                        dataToChange.RemoveRange(start, count);
                        dataToChange.InsertRange(start, theNewStr);
                    }
                }
                else if (inputTokens[0] == "rollLeft")
                {
                    int count = int.Parse(inputTokens[1]);

                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                    else
                    {
                        count = count % dataToChange.Count;
                        for (int i = 0; i < count; i++)
                        {
                            dataToChange.Insert(dataToChange.Count, dataToChange[0]);
                            dataToChange.RemoveAt(0);
                        }
                    }

                    // Console.WriteLine(string.Join(" ",dataToChange));
                }
                else if (inputTokens[0] == "rollRight")
                {
                    int count = int.Parse(inputTokens[1]);

                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                    else
                    {
                        count = count % dataToChange.Count;
                        for (int i = 0; i < count; i++)
                        {
                            dataToChange.Insert(0, dataToChange[dataToChange.Count - 1]);
                            dataToChange.RemoveAt(dataToChange.Count - 1);
                        }
                    }

                    // Console.WriteLine(string.Join(" ", dataToChange));
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"[{string.Join(", ", dataToChange)}]");
        }
    }
}