using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); //distance between targets
            int m = int.Parse(Console.ReadLine()); //poke power
            int y = int.Parse(Console.ReadLine()); //exhaustion factor

            int targetCount = 0;
            double originalValueHalf = n * 0.5;

            while (n >= m)
            {
                n -= m;
                targetCount++;

                if (n == originalValueHalf && y > 0)
                    n /= y;                
            }

            Console.WriteLine(n);
            Console.WriteLine(targetCount);
        }
    }
}