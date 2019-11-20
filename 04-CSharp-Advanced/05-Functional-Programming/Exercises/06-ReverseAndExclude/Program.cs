using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int divNumber = int.Parse(Console.ReadLine());

            Action<List<int>> reverseNums = n => n.Reverse();
            Func<List<int>, List<int>> findNums = n => n.Where(x => x % divNumber != 0).ToList();
            Action<List<int>> print = n => Console.WriteLine(string.Join(' ', n));

            reverseNums(numbers);
            numbers = findNums(numbers);
            print(numbers);
        }
    }
}
