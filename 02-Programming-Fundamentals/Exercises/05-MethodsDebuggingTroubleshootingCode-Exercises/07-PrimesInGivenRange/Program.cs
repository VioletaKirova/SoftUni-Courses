using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_PrimesInGivenRange
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingNum = int.Parse(Console.ReadLine());
            int endingNum = int.Parse(Console.ReadLine());
            string primeNumbers = FindPrimeNumbersInRange(startingNum, endingNum);
            primeNumbers = primeNumbers.Substring(0, primeNumbers.Length - 2); ;
            Console.WriteLine(primeNumbers);
        }
        
        static string FindPrimeNumbersInRange(int startingNum, int endingNum)
        {
            string primeNumbers = "";

            for (int i = startingNum; i <= endingNum; i++)
            {
                if (i == 0 || i == 1)
                {
                    i = 2;
                }

                bool isPrime = true;

                for (int l = 2; l <= Math.Sqrt(i); l++)
                {
                    if (i % l == 0)
                    {
                        isPrime = false;
                        break;
                    }                    
                }

                if (isPrime)
                {
                    primeNumbers += $"{i}, ";
                }
            }

            return primeNumbers;
        }
    }
}
