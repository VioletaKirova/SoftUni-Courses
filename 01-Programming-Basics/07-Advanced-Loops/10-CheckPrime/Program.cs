using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_CheckPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            bool isPrime = true;

            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                { 
                    isPrime = false;
                    break;
                }
            }

            if (n < 2)
            {
                isPrime = false;
            }

            if (isPrime)
            {
                Console.WriteLine("Prime");
            }
            else
            {
                Console.WriteLine("Not Prime");
            }
        }
    }
}
