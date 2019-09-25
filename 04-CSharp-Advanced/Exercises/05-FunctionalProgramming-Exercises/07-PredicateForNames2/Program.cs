using System;
using System.Linq;

namespace _07_PredicateForNames2
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            string[] inputNames = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Action<string[]> filteredNames = names => Console.WriteLine(string.Join("\n", names.Where(x => x.Length <= length).ToArray()));

            filteredNames(inputNames);
        }
    }
}
