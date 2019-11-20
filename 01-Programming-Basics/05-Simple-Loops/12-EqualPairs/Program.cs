using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_EqualPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            int currentSum = 0;
            int diff = 0;
            int maxDiff = 0;

            for (int i = 0; i < n; i++)
            {
                int num1 = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());

                sum = num1 + num2;

                if (i > 0 && sum != currentSum)
                {
                    diff = Math.Abs(sum - currentSum);

                    if (diff > maxDiff)
                    {
                        maxDiff = diff;
                    }
                }

                currentSum = sum;
            }

            if (maxDiff == 0)
            {
                Console.WriteLine($"Yes, value={currentSum}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={maxDiff}");
            }
        }
    }
}
