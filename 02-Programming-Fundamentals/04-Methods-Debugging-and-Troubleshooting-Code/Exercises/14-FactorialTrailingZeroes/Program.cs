using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _14_FactorialTrailingZeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger factorial = CalculateFactorial(n);
            BigInteger zeroesCount = CountZeroes(factorial);
            Console.WriteLine(zeroesCount);
        }

        static BigInteger CalculateFactorial(int n)
        {
            BigInteger factorial = 1;

            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

        static int CountZeroes(BigInteger factorial)
        {
            int zeroesCount = 0;

            while (factorial % 10 == 0)
            {
                zeroesCount++;
                factorial /= 10;
            }

            return zeroesCount;
        }
    }
}
