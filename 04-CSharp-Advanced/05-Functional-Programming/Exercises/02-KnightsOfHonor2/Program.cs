using System;
using System.Linq;

namespace _02_KnightsOfHonor2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Action<string[]> print = x => Console.WriteLine("Sir " + string.Join("\nSir ", x));

            print(names);
        }
    }
}
