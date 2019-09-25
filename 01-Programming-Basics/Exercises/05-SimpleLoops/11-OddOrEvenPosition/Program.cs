using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_OddOrEvenPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double oddSum = 0;
            double oddMin = double.MaxValue;
            double oddMax = double.MinValue;

            double evenSum = 0;
            double evenMin = double.MaxValue;
            double evenMax = double.MinValue;

            for (int i = 1; i <= n; i++)
            {
                double currentNum = double.Parse(Console.ReadLine());

                if (i % 2 != 0)
                {
                    oddSum += currentNum;

                    if (currentNum > oddMax) oddMax = currentNum;
                    if (currentNum < oddMin) oddMin = currentNum;
                }
                else
                {
                    evenSum += currentNum;

                    if (currentNum > evenMax) evenMax = currentNum;
                    if (currentNum < evenMin) evenMin = currentNum;
                }
            }

            //Odd
            Console.WriteLine($"OddSum={oddSum}");

            if (oddMin != double.MaxValue) Console.WriteLine($"OddMin={oddMin}");
            else Console.WriteLine($"OddMin=No");

            if(oddMax != double.MinValue) Console.WriteLine($"OddMax={oddMax}");
            else Console.WriteLine($"OddMax=No");

            //Even
            Console.WriteLine($"EvenSum={evenSum}");

            if (evenMin != double.MaxValue) Console.WriteLine($"EvenMin={evenMin}");
            else Console.WriteLine($"EvenMin=No");

            if (evenMax != double.MinValue) Console.WriteLine($"EvenMax={evenMax}");
            else Console.WriteLine($"EvenMax=No");
        }
    }
}
