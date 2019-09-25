using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Axe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int starsCount = 0;
            int dashesCount = 0;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}*{1}*{2}", new string ('-', 3 * n),
                    new string ('-', i),
                    new string ('-', 2 * n - 2 - i));
            }

            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine("{0}*{1}*{1}", new string ('*', 3 * n),
                    new string ('-', n - 1));
            }

            for (int i = 0; i < n / 2 - 1; i++)
            {
                Console.WriteLine("{0}*{1}*{2}", new string('-', 3 * n - i),
                    new string('-', n - 1 + 2 * i),
                    new string('-', n - 1 - i));

                if (i == n / 2 - 2)
                {
                    starsCount = n - 1 + 2 * i;
                    dashesCount = 3 * n - i;
                }
            }

            starsCount += 4;
            dashesCount--;

            Console.WriteLine("{0}{1}{2}", new string ('-', dashesCount),
                new string ('*', starsCount),
                new string ('-', 5 * n - dashesCount - starsCount));
        }
    }
}
