using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ConsoleApplication9
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger[] input = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToArray();
            int baseN = (int)input[0];
            BigInteger base10 = input[1];
            BigInteger remainder;
            string result = null;

            while (base10 > 0)
            {
                remainder = base10 % baseN;
                base10 /= baseN;
                result = remainder.ToString() + result;
            }

            Console.WriteLine(result);
        }
    }
}