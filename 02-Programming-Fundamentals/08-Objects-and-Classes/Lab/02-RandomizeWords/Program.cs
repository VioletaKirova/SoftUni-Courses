using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(' ').ToList();

            Random rnd = new Random();

            for (int pos1 = 0; pos1 < input.Count; pos1++)
            {
                int pos2 = rnd.Next(input.Count);
                string old = input[pos1];
                input[pos1] = input[pos2];
                input[pos2] = old;
            }

            Console.WriteLine(string.Join("\r\n", input));
        }
    }
}