using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_AnonymousThreat3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(' ').ToList();
            string inputCommand = Console.ReadLine();

            while (inputCommand != "3:1")
            {
                string[] commands = inputCommand.Split(' ').ToArray();
                string command = commands[0];

                if (command == "merge")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);

                    if (startIndex < 0 || startIndex > input.Count)
                        startIndex = 0;

                    if (endIndex < 0 || endIndex > input.Count - 1)
                        endIndex = input.Count - 1;

                    string concat = "";

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        concat += input[i];
                    }

                    input.RemoveRange(startIndex, endIndex - startIndex + 1);
                    input.Insert(startIndex, concat);

                }
                else if (command == "divide")
                {
                    int index = int.Parse(commands[1]);
                    int parts = int.Parse(commands[2]);

                    string word = input[index];
                    int partLen = word.Length / parts;
                    List<string> dividedWord = new List<string>();

                    for (int i = 0; i < parts; i++)
                    {
                        string current = "";

                        if (i == parts - 1)
                            current = word.Substring(i * partLen);
                        else
                            current = word.Substring(i * partLen, partLen);

                        dividedWord.Add(current);                        
                    }

                    input.RemoveAt(index);
                    input.InsertRange(index, dividedWord);
                }

                inputCommand = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}