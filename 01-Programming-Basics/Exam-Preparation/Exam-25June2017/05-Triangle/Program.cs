using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(new string ('#', 4 * n + 1));

            int hashtagCount = 2 * n - 1;
            int spacesCount = 1;
            int bottomDotsCount = n + 1;
            int bottomHashtagCount = 2 * n - 1;

            for (int i = 1; i <= n; i++)
            {
                if (i == n / 2 + 1)
                {
                    Console.WriteLine("{0}{1}{2}(@){2}{1}{0}", new string('.', i),
                                                 new string('#', (hashtagCount)),
                                                 new string(' ', ((spacesCount - 3) / 2)));
                }
                else
                {
                    Console.WriteLine("{0}{1}{2}{1}{0}", new string ('.', i),
                                                 new string ('#', hashtagCount),
                                                 new string (' ', spacesCount));
                }

                hashtagCount -= 2;
                spacesCount += 2;
            }

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("{0}{1}{0}", new string ('.', bottomDotsCount),
                                               new string ('#', bottomHashtagCount));
                bottomDotsCount++;
                bottomHashtagCount -= 2;
            }           
        }
    }
}
