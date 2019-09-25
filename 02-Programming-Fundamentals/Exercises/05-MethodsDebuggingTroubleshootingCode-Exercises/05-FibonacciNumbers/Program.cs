using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_FibonacciNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int fibonacciNumber = GiveFibonacciNumber(n);
            Console.WriteLine(fibonacciNumber);
        }

        static int GiveFibonacciNumber(int number)
        {
            if (number < 2)
            {
                return 1;
            }

            int f1 = 1;
            int f2 = 1;
            int f3 = 0;

            for (int i = 2; i <= number; i++)
            {
                f3 = f2;
                f2 += f1;
                f1 = f3;
            }

            return f2;
        }
    }
}
