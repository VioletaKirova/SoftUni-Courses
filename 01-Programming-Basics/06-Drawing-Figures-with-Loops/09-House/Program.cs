using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_House
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int startingStars = 1;

            if (n % 2 == 0)
            {
                startingStars = 2;
            }

            for (int i = 0; i < (n + 1) / 2; i++)
            {
                Console.WriteLine("{0}{1}{0}", 
                    new string ('-', (n - startingStars) / 2),
                    new string ('*', startingStars));
                startingStars += 2;
            }

            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine("|{0}|", new string ('*', n - 2));
            }
        }
    }
}
