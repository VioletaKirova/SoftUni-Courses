using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_ShortWordsSorted
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separators = new char[] 
            {
                '.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '\\', '/', '!', '?', ' '
            };

            List<string> words = Console.ReadLine().ToLower().Split(separators).ToList();

            words = words.Distinct()
                .Where(word => word != "")
                .Where(word => word.Length < 5)
                .OrderBy(word => word)
                .ToList();

            Console.WriteLine(string.Join(", ", words));
        }
    }
}