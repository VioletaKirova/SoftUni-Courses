using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Sheriff
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            // First Three Rows:
            Console.Write(new string('.', (n + ((n - 1) / 2))));
            Console.Write("x");
            Console.Write(new string('.', (n + ((n - 1) / 2))));
            Console.WriteLine();

            Console.Write(new string('.', (n + ((n - 3) / 2))));
            Console.Write("/x\\");
            Console.Write(new string('.', (n + ((n - 3) / 2))));
            Console.WriteLine();

            Console.Write(new string('.', (n + ((n - 3) / 2))));
            Console.Write("x|x");
            Console.Write(new string('.', (n + ((n - 3) / 2))));
            Console.WriteLine();

            for (int i = ((n - 1) / 2); i >= 0; i--)
            {
                Console.Write(new string('.', i));
                Console.Write(new string('x', ((n * 3 - i * 2 - 1) / 2)));
                Console.Write("|");
                Console.Write(new string('x', ((n * 3 - i * 2 - 1) / 2)));
                Console.WriteLine(new string('.', i));
            }

            for (int j = 1; j <= ((n - 1) / 2); j++)
            {
                Console.Write(new string('.', j));
                Console.Write(new string('x', ((n * 3 - j * 2 - 1) / 2)));
                Console.Write("|");
                Console.Write(new string('x', ((n * 3 - j * 2 - 1) / 2)));
                Console.WriteLine(new string('.', j));
            }

            //Middle Row 1:
            Console.Write(new string('.', (n + ((n - 3) / 2))));
            Console.Write("/x\\");
            Console.Write(new string('.', (n + ((n - 3) / 2))));
            Console.WriteLine();

            //Middle Row 2:
            Console.Write(new string('.', (n + ((n - 3) / 2))));
            Console.Write("\\x/");
            Console.Write(new string('.', (n + ((n - 3) / 2))));
            Console.WriteLine();

            for (int l = ((n - 1) / 2); l >= 0; l--)
            {
                Console.Write(new string('.', l));
                Console.Write(new string('x', ((n * 3 - l * 2 - 1) / 2)));
                Console.Write("|");
                Console.Write(new string('x', ((n * 3 - l * 2 - 1) / 2)));
                Console.WriteLine(new string('.', l));
            }

            for (int k = 1; k <= ((n - 1) / 2); k++)
            {
                Console.Write(new string('.', k));
                Console.Write(new string('x', ((n * 3 - k * 2 - 1) / 2)));
                Console.Write("|");
                Console.Write(new string('x', ((n * 3 - k * 2 - 1) / 2)));
                Console.WriteLine(new string('.', k));
            }

            //Last Three Rows:
            Console.Write(new string('.', (n + ((n - 3) / 2))));
            Console.Write("x|x");
            Console.Write(new string('.', (n + ((n - 3) / 2))));
            Console.WriteLine();

            Console.Write(new string('.', (n + ((n - 3) / 2))));
            Console.Write("\\x/");
            Console.Write(new string('.', (n + ((n - 3) / 2))));
            Console.WriteLine();

            Console.Write(new string('.', (n + ((n - 1) / 2))));
            Console.Write("x");
            Console.Write(new string('.', (n + ((n - 1) / 2))));
            Console.WriteLine();
        }
    }
}
