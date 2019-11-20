using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_HalfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int maxValue = int.MinValue;
            int numberSum = 0;

            for (int i = 0; i < n; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());

                numberSum += currentNum;

                if (currentNum > maxValue)
                {
                    maxValue = currentNum;
                }
            }

            if (numberSum - maxValue == maxValue)
            {
                Console.WriteLine($"Yes Sum = {maxValue}");
            }
            else
            {
                int diff = Math.Abs((numberSum - maxValue) - maxValue);
                Console.WriteLine($"No Diff = {diff}");
            }
        }
    }
}
