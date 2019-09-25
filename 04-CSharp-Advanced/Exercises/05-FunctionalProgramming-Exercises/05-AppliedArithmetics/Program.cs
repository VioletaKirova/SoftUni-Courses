using System;
using System.Linq;

namespace _05_AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int[]> addOneFunc = nums => nums.Select(x => x + 1).ToArray();
            Func<int[], int[]> subtractOneFunc = nums => nums.Select(x => x - 1).ToArray();
            Func<int[], int[]> multiplyByTwoFunc = nums => nums.Select(x => x * 2).ToArray();
            Action<int[]> printNumbers = nums => Console.WriteLine(string.Join(' ', nums));

            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            while (command != "end")
            {
                if (command == "add")
                {
                    numbers = addOneFunc(numbers);
                }
                else if (command == "subtract")
                {
                    numbers = subtractOneFunc(numbers);
                }
                else if (command == "multiply")
                {
                    numbers = multiplyByTwoFunc(numbers);
                }
                else if (command == "print")
                {
                    printNumbers(numbers);
                }

                command = Console.ReadLine();
            }

        }
    }
}
