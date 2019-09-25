using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_SumOfOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var oddNum = 1;
            var sum = 0;

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(oddNum);
                sum += oddNum;
                oddNum += 2;
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
