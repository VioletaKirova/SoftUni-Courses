using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_SortTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(' ')
                .OrderBy(x => x)
                .ToList();

            Console.WriteLine(string.Join(", ", input));
        }
    }
}