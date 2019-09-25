using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int width = 3 * n + 6;
            int middlePartSpaces = n - 1;
            int coffeeWidth = width - 3 - middlePartSpaces; 

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}~ ~ ~", new string (' ', n));
            }

            Console.WriteLine(new string ('=', width - 1));

            for (int i = 0; i < n - 2; i++)
            {
                if (i == (n - 2) / 2)
                {
                    Console.WriteLine("|{0}JAVA{0}|{1}|", new string('~', (width - 7 - middlePartSpaces) / 2),
                    new string(' ', middlePartSpaces));
                }
                else
                {
                    Console.WriteLine("|{0}|{1}|", new string('~', width - 3 - middlePartSpaces),
                   new string(' ', middlePartSpaces));
                }
            }

            Console.WriteLine(new string('=', width - 1));

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}\\{1}/", new string (' ', i),
                    new string ('@', coffeeWidth));

                coffeeWidth -= 2;
            }

            Console.WriteLine(new string('=', width - middlePartSpaces - 1));
        }
    }
}
