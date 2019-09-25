using System;
using System.Linq;

namespace _07_PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            string[] inputNames = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Func<string[], string[]> filteredNames = names => names.Where(x => x.Length <= length).ToArray();

            inputNames = filteredNames(inputNames);

            foreach (var name in inputNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
