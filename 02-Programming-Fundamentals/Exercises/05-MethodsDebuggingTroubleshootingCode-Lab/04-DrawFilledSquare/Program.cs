using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_DrawFilledSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintHeaderOrFooter(n);

            for (int i = 0; i < n - 2; i++)
            {
                PrintMiddleRow(n);
            }

            PrintHeaderOrFooter(n);
        }

        static void PrintHeaderOrFooter(int number)
        {
            Console.WriteLine(new string('-', 2 * number));
        }

        static void PrintMiddleRow(int number)
        {
            Console.Write("-");

            for (int i = 1; i <= number - 1; i++)
            {
                Console.Write("\\/");
            }

            Console.WriteLine("-");
        }
    }
}
