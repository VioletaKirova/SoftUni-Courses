using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_AnonymousThreat
{
    // not finished
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(' ').ToList();

            string commandInput = Console.ReadLine();

            while (commandInput != "3:1")
            {
                string[] commandArr = commandInput.Split(' ').ToArray();
                string command = commandArr[0];

                if (command == "merge")
                {
                    int startIndex = int.Parse(commandArr[1]);
                    int endIndex = int.Parse(commandArr[2]);

                    string newStr = "";

                    if (endIndex + 1 > input.Count)
                    {
                        endIndex = input.Count - 1;
                    }

                    for (int i = startIndex; i < endIndex; i++)
                    {
                        newStr += input[i];
                    }

                    input[startIndex] = newStr;
                    input.RemoveRange(startIndex + 1, endIndex - startIndex - 1);
                }
                else if (command == "divide")
                {
                    int index = int.Parse(commandArr[1]);
                    int partitions = int.Parse(commandArr[2]);

                    string element = input[index];

                    List<string> partitionsList = new List<string>();

                    if (element.Length % partitions == 0)
                    {
                        int partitionLen = element.Length / partitions;

                        for (int i = 0; i < element.Length; i += partitionLen)
                        {
                            string currentPartition = "";

                            for (int j = 0; j < partitionLen; j++)
                            {
                                currentPartition += element[j];
                            }

                            partitionsList.Add(currentPartition);
                        }
                    }
                    else
                    {
                        // not finished                       
                    }
                }

                commandInput = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}