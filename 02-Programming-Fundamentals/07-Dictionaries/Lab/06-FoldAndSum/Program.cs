using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int k = inputArr.Length / 4;

            int[] leftPart = inputArr.Take(k).Reverse().ToArray();
            int[] rightPart = inputArr.Reverse().Take(k).ToArray();
            int[] firstRow = leftPart.Concat(rightPart).ToArray();

            int[] secondRow = inputArr.Skip(k).Take(2 * k).ToArray();

            int[] sum = firstRow.Select((x, index) => x + secondRow[index]).ToArray();
            Console.WriteLine(string.Join(" ", sum));
        }
    }
}