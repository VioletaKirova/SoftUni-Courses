using System;
using System.Collections.Generic;

namespace _03_PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> chemicalCompounds = new SortedSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] compounds = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var compound in compounds)
                {
                    chemicalCompounds.Add(compound);                 
                }
            }

            Console.WriteLine(string.Join(' ', chemicalCompounds));
        }
    }
}
