using System;
using System.Collections.Generic;

namespace _05_CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            SortedDictionary<char, int> chars = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (!chars.ContainsKey(currentChar))
                {
                    chars[currentChar] = 0;
                }

                chars[currentChar]++;
            }

            foreach (var c in chars)
            {
                Console.WriteLine($"{c.Key}: {c.Value} time/s");
            }
        }
    }
}
