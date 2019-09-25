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

            Action<string> print = x => Console.WriteLine(x);

            foreach (var name in names)
            {
                print(name);
            }
        }
    }
}
