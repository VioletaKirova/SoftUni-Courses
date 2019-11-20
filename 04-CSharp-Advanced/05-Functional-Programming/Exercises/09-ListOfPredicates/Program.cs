using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int rangeLength = int.Parse(Console.ReadLine());

            List<int> numbers = new List<int>();

            int[] dividers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int[], bool> checkNum = CheckNum;
           
            int currentNumber = 1;

            for (int i = 0; i < rangeLength; i++)
            {
                if (checkNum(currentNumber, dividers))
                {
                    numbers.Add(currentNumber);
                }

                currentNumber++;
            }

            Console.WriteLine(string.Join(' ', numbers));

        }

        private static bool CheckNum(int currentNum, int[] dividers)
        {
            bool isDivisibleByAll = true;

            foreach (var div in dividers)
            {
                if (currentNum % div != 0)
                {
                    isDivisibleByAll = false;
                }
            }

            return isDivisibleByAll;
        }
    }
}
