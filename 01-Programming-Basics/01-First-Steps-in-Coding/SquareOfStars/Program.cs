using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(new string('*', n));

            for (int i = 0; i < n - 2; i++)
            {
                string spaces = new string(' ', n - 2);

                Console.WriteLine($"*{spaces}*");
            }

            Console.WriteLine(new string('*', n));
        }
    }
}
