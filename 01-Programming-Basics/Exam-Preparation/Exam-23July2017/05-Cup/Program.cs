using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Cup
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            //First Half
            for (int i = 0; i < (n + 1) / 2; i++)
            {
                Console.Write(new string('.', n + i));
                Console.Write(new string('#', (n * 3 - i * 2)));
                Console.WriteLine(new string('.', n + i));
            }

            for (int l = (n + 1) / 2; l < n + 1; l++)
            {
                Console.Write(new string('.', n + l));
                Console.Write('#');
                Console.Write(new string('.', (n * 3 - (l * 2 + 2))));
                Console.Write('#');
                Console.WriteLine(new string('.', n + l));
            }

            //Middle Row
            Console.Write(new string('.', n * 2));
            Console.Write(new string('#', n));
            Console.WriteLine(new string('.', n * 2));

            //Second Half
            for (int h = 1; h <= n / 2; h++)
            {
                Console.Write(new string('.', n * 2 - 2));
                Console.Write(new string('#', (n * 5 - (n * 2 - 2) * 2)));
                Console.WriteLine(new string('.', n * 2 - 2));
            }

            //Text
            Console.Write(new string('.', (n * 5 - 10) /2));
            Console.Write("D^A^N^C^E^");
            Console.WriteLine(new string('.', (n * 5 - 10) / 2));

            for (int h = 1; h <= n / 2 + 1; h++)
            {
                Console.Write(new string('.', n * 2 - 2));
                Console.Write(new string('#', (n * 5 - (n * 2 - 2) * 2)));
                Console.WriteLine(new string('.', n * 2 - 2));
            }
        }
    }
}
