using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_OddNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 10; i++)
            {
                var number = int.Parse(Console.ReadLine());

                if (number % 2 != 0)
                {
                    Console.WriteLine($"The number is: {Math.Abs(number)}");
                    break;
                }

                Console.WriteLine("Please write an odd number.");
            }
        }
    }
}
