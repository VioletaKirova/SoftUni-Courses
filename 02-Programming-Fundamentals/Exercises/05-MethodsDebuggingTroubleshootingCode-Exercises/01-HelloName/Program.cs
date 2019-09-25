using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_HelloName
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintGreeting();
        }

        static void PrintGreeting()
        {
            string name = Console.ReadLine();
            Console.WriteLine("Hello, {0}!", name);
        }
    }
}
