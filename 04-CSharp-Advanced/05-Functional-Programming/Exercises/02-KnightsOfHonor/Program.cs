using System;
using System.Linq;

namespace _02_KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Action<string> addSir = x => Console.WriteLine("Sir " + x);

            foreach (var name in names)
            {
                addSir(name);
            }
        }
    }
}
