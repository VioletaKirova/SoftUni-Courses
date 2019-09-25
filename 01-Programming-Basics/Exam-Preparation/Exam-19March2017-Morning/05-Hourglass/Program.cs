using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Hourglass
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int width = 2 * n + 1;

            Console.WriteLine(new string ('*', width));

            for (int i = 1; i <= n - 1; i++)
            {
                if (i == 1)
                {
                    Console.WriteLine("{0}*{1}*{0}", new string('.', i),
                    new string(' ', (width - 2 * i) - 2));
                }
                else
                {
                    Console.WriteLine("{0}*{1}*{0}", new string ('.', i),
                    new string ('@', (width - 2 * i) - 2));
                }
            }

            Console.WriteLine("{0}*{0}", new string ('.', (width - 1) / 2));

            for (int i = n - 1; i >= 1; i--)
            {
                if (i == 1)
                {
                    Console.WriteLine("{0}*{1}*{0}", new string('.', i),
                    new string('@', width - 2 - 2 * 1));
                }
                else
                {
                    Console.WriteLine("{0}*{1}@{1}*{0}", new string('.', i),
                    new string(' ', ((width - 2 * i) - 3) / 2));
                }
            }

            Console.WriteLine(new string('*', width));
        }
    }
}
