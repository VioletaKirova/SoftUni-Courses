using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_X
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var middleSpace = n - 2;

            for (int i = 1; i <= n / 2; i++)
            {
                Console.WriteLine("{1}x{0}x", new string (' ', middleSpace), new string(' ', (n - 2 - middleSpace) / 2));
                middleSpace -= 2;
            }

            Console.WriteLine("{0}x", new string (' ', n / 2));

            middleSpace = 1;

            for (int i = n / 2; i >= 1; i--)
            {
                Console.WriteLine("{1}x{0}x", new string(' ', middleSpace), new string(' ', (n - 2 - middleSpace) / 2));
                middleSpace += 2;
            }
        }
    }
}
