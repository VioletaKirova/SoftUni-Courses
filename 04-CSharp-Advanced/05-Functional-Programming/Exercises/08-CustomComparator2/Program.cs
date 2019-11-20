using System;
using System.Linq;

namespace _08_CustomComparator2
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

            Func<int[], int[]> findEvenNums = n => n.Where(x => x % 2 == 0).ToArray();
            Func<int[], int[]> findOddNums = n => n.Where(x => x % 2 != 0).ToArray();

            int[] evenNums = findEvenNums(inputNumbers);
            int[] oddNums = findOddNums(inputNumbers);

            Console.WriteLine(string.Join(' ', evenNums) + " " + string.Join(' ', oddNums));
        }
    }
}
