using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_GreatestCommonDivisor
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            int smaller = Math.Min(a, b);
            int bigger = Math.Max(a, b);

            while (smaller != 0)
            {
                int next = bigger % smaller;
                bigger = smaller;
                smaller = next;
            }

            Console.WriteLine(bigger);

            //int max = Math.Max(a, b);
            //int divisor = 1;
            //int gcd = 1;

            //for (int i = 1; i <= max; i++)
            //{
            //    if (a % divisor == 0 && b % divisor == 0)
            //    {
            //        gcd = divisor;
            //    }
            //    divisor++;
            //}

            //Console.WriteLine(gcd);
        }
    }
}
