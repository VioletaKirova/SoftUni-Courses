using System;
using System.Linq;

namespace _04_FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isEven = n => n % 2 == 0; 
            Predicate<int> isOdd = n => n % 2 != 0;

            int[] rangeBounds = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] numbers = new int[rangeBounds[1] - rangeBounds[0] + 1];

            int index = 0;

            for (int i = rangeBounds[0]; i <= rangeBounds[1]; i++)
            {
                numbers[index] = i;
                index++;
            }

            string command = Console.ReadLine();

            if (command == "even")
            {
                Console.WriteLine(string.Join(' ', numbers.Where(n => isEven(n))));
            }
            else if(command == "odd")
            {
                Console.WriteLine(string.Join(' ', numbers.Where(n => isOdd(n))));
            }
        }
    }
}
