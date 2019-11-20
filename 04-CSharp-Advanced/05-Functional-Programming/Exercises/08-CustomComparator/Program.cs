using System;
using System.Linq;

namespace _08_CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderBy(x => x)
                .ToArray();

            Action<int[]> printEvenNums = n => Console.Write(string.Join(" ", n.Where(x => x % 2 == 0)));
            Action<int[]> printOddNums = n => Console.Write(" " + string.Join(" ", n.Where(x => x % 2 != 0)));

            printEvenNums(inputNumbers);
            printOddNums(inputNumbers);
            Console.WriteLine();
        }
    }
}
