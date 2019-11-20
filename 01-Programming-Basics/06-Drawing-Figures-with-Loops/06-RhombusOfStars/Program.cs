using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_RhombusOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = n - 1; i >= 0; i--)
            {
                Console.Write(new string (' ', i));
                for (int j = 1; j <= n - i; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }

            for (int i = 1; i < n; i++)
            {
                Console.Write(new string (' ', i));
                for (int j = 1; j <= n - i; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
    }
}
