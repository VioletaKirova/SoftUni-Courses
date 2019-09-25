using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_SoftUniLogo
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int width = 12 * n - 5;
            int middleTopPart = 1;
            int dotsCount = 3;

            for (int i = 0; i < 2 * n; i++)
            {
                Console.WriteLine("{0}{1}{0}", new string ('.', (width - middleTopPart) / 2),
                    new string ('#', middleTopPart));

                middleTopPart += 6;
            }

            for (int i = 0; i < n - 2; i++)
            {
                Console.WriteLine("|{0}{1}{2}", new string('.', (dotsCount - 1)),
                    new string('#', width - dotsCount * 2),
                    new string ('.', dotsCount));

                dotsCount += 3;
            }
            
            for (int i = 0; i < n; i++)
            {
                if (i == n - 1)
                {
                    Console.WriteLine("@{0}{1}{2}", new string('.', (dotsCount - 1)),
                    new string('#', width - dotsCount * 2),
                    new string('.', dotsCount));
                }
                else
                {
                    Console.WriteLine("|{0}{1}{2}", new string('.', (dotsCount - 1)),
                    new string('#', width - dotsCount * 2),
                    new string('.', dotsCount));
                }
            }
        }
    }
}
