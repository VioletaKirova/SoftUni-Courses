using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int currentDigit = n % 10;
            int number = n;
            int sum = 0;

            while (number > 0)
            {
                sum += currentDigit;
                number = number / 10;
                currentDigit = number % 10;
            }

            Console.WriteLine(sum);
        }
    }
}
