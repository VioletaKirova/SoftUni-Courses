using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int allDigits = n;

            int thirdNumber = allDigits % 10;
            allDigits /= 10;

            int secondNumber = allDigits % 10;
            allDigits /= 10;

            int firstNumber = allDigits % 10;

            int rows = firstNumber + secondNumber;
            int columns = firstNumber + thirdNumber;

            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= columns; j++)
                {
                    if (n % 5 == 0)
                    {
                        n -= firstNumber;
                    }
                    else if (n % 3 == 0)
                    {
                        n -= secondNumber;
                    }
                    else
                    {
                        n += thirdNumber;
                    }

                    Console.Write(n + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
