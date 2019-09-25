using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] setsLength = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int firstSetLen = setsLength[0];
            int secondSetLen = setsLength[1];

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < firstSetLen; i++)
            {
                int number = int.Parse(Console.ReadLine());

                firstSet.Add(number);
            }

            for (int i = 0; i < secondSetLen; i++)
            {
                int number = int.Parse(Console.ReadLine());

                secondSet.Add(number);
            }

            foreach (var num in firstSet)
            {
                if (secondSet.Contains(num))
                {
                    Console.Write(num + " ");
                }
            }

            Console.WriteLine();
        }
    }
}
