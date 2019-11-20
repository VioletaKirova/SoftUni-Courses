using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int multiplied = MultiplyEvenByOdd(n);
            Console.WriteLine(multiplied);
        }

        static int MultiplyEvenByOdd(int n)
        {
            int evenSum = GetSumOfEvenDigits(n);
            int oddSum = GetSumOfOddDigits(n);
            return evenSum * oddSum;
        }

        static int GetSumOfEvenDigits(int n)
        {
            int sum = 0;

            while (Math.Abs(n) > 0)
            {
                int lastDigit = Math.Abs(n % 10);

                if (lastDigit % 2 == 0)
                {
                    sum += lastDigit;
                }

                n /= 10;
            }

            return sum;
        }

        static int GetSumOfOddDigits(int n)
        {
            int sum = 0;

            while (Math.Abs(n) > 0)
            {
                int lastDigit = Math.Abs(n % 10);

                if (lastDigit % 2 != 0)
                {
                    sum += lastDigit;
                }

                n /= 10;
            }

            return sum;
        }
    }
}
