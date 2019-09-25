using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_SumOrMultiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            int mult = 0;

            bool threreIsSum = false;
            bool threreIsMult = false;

            for (int a = 1; a <= 30; a++)
            {
                for (int b = 1; b <= 30; b++)
                {
                    for (int c = 1; c <= 30; c++)
                    {
                        sum = a + b + c;
                        mult = a * b * c;

                        if (sum == n && a < b && b < c)
                        {
                            threreIsSum = true;
                            Console.WriteLine($"{a} + {b} + {c} = {sum}");
                        }

                        if (mult == n && a > b && b > c)
                        {
                            threreIsMult = true;
                            Console.WriteLine($"{a} * {b} * {c} = {mult}");
                        }
                    }
                }
            }
            if (threreIsSum == false && threreIsMult == false)
            {
                Console.WriteLine("No!");
            }
        }
    }
}
