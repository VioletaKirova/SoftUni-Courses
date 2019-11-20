using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int currentNum = i;
                int digitSum = 0;
                int digit = 0;

                while (currentNum > 0)
                {
                    digit = currentNum % 10;
                    digitSum += digit;
                    currentNum /= 10;
                }

                if (digitSum == 5 || digitSum == 7 || digitSum == 11)
                    Console.WriteLine($"{i} -> True");
                else
                    Console.WriteLine($"{i} -> False");
            }
        }
    }
}
