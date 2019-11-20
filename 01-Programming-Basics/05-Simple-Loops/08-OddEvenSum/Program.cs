using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_OddEvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int evenSum = 0;
            int oddSum = 0;

            for (int i = 0; i < n; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    evenSum += currentNum;
                }
                else
                {
                    oddSum += currentNum;
                }
            }

            if (evenSum == oddSum)
            {
                Console.WriteLine($"Yes Sum = {evenSum}");
            }
            else
            {
                Console.WriteLine($"No Diff = {Math.Abs(evenSum - oddSum)}");
            }
        }
    }
}
