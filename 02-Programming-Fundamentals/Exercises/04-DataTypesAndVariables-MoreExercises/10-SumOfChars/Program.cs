using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_SumOfChars
{
    class Program
    {
        static void Main(string[] args)
        {
            sbyte n = sbyte.Parse(Console.ReadLine());
            int sum = 0;

            for (sbyte i = 0; i < n; i++)
            {
                char character = char.Parse(Console.ReadLine());
                sum += (int)character;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
