using System;
using System.Linq;

namespace _03_GroupNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] firstGroup = numbers.Where(x => Math.Abs(x) % 3 == 0).ToArray();
            int[] secondGroup = numbers.Where(x => Math.Abs(x) % 3 == 1).ToArray();
            int[] thirdGroup = numbers.Where(x => Math.Abs(x) % 3 == 2).ToArray();

            int[][] jaggedArray = new int[3][];

            jaggedArray[0] = firstGroup;
            jaggedArray[1] = secondGroup;
            jaggedArray[2] = thirdGroup;

            foreach (var row in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
