using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Crown
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int middleDotsCount = 1;

            //First two rows
            Console.WriteLine("@{0}@{0}@", new string (' ', n - 2));
            Console.WriteLine("**{0}*{0}**", new string (' ', n - 3));

            for (int i = 1; i <= n / 2; i++)
            {
                if (i == n / 2)
                {
                    Console.WriteLine("*{0}{1}.{1}{0}*", new string('.', i),
                    new string ('*', (2 * n - 3 - 2 * i) / 2));
                }
                else if (i == n / 2 - 1)
                {
                    Console.WriteLine("*{0}*{1}*{0}*", new string('.', i),
                    new string('.', middleDotsCount));
                }
                else
                {
                    Console.WriteLine("*{0}*{1}*{2}*{1}*{0}*", new string('.', i),
                                        new string(' ', (2 * n - 7 - 2 * i - middleDotsCount) / 2),
                                        new string('.', middleDotsCount));
                }
                          
                middleDotsCount += 2;
            }

            //Last two rows
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(new string ('*', 2 * n - 1));
            }
        }
    }
}
