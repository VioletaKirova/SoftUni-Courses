using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_TestNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());
            var max = int.Parse(Console.ReadLine());

            var current = 0;
            var totalSum = 0;
            var count = 0;

            bool maxReached = false;

            for (int i = n; i >= 1; i--)
            {
                for (int l = 1; l <= m; l++)
                {
                    current = i * l * 3;
                    totalSum += current;
                    count++;

                    if (totalSum >= max)
                    {
                        maxReached = true;
                        break;
                    }
                }

                if (maxReached)
                {
                    break;
                }
            }

            if (maxReached)
            {
                Console.WriteLine($"{count} combinations");
                Console.WriteLine($"Sum: {totalSum} >= {max}");
            }
            else
            {
                Console.WriteLine($"{count} combinations");
                Console.WriteLine($"Sum: {totalSum}");
            }
        }
    }
}
