using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_OddFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> evenNums = input.Where(x => x % 2 == 0).ToList();

            double average = evenNums.Average();

            List<int> convertedToOdd = new List<int>(evenNums.Count);

            foreach (var num in evenNums)
            {
                int oddNum = 0;

                if (num > average)
                    oddNum = num + 1;
                else
                    oddNum = num - 1;

                convertedToOdd.Add(oddNum);
            }

            Console.WriteLine(string.Join(" ", convertedToOdd));
        }
    }
}