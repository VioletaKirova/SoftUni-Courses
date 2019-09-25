using System;
using System.Linq;

namespace _03_CustomMinFunction
{
    class Program
    {
        static Func<int[], int> findSmallestNumber = n => n.Min();

        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(findSmallestNumber(numbers));
        }
    }
}
