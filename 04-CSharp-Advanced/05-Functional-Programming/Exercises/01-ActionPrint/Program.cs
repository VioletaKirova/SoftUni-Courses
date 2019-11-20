using System;
using System.Linq;

namespace _01_ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Action<string> print = Print;

            foreach (var name in names)
            {
                print(name);
            }
        }

        static void Print(string name)
        {
            Console.WriteLine(name);
        }
    }
}
