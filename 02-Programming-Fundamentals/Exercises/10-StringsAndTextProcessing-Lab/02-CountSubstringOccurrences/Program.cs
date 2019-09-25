using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_CountSubstringOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            string pattern = Console.ReadLine().ToLower();

            int counter = 0;
            int index = input.IndexOf(pattern);

            while (index != -1)
            {
                counter++;
                index = input.IndexOf(pattern, index + 1);
            }

            Console.WriteLine(counter);
        }
    }
}