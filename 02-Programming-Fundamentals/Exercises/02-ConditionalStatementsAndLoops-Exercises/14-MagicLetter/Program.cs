using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_MagicLetter
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = char.Parse(Console.ReadLine());
            var second = char.Parse(Console.ReadLine());
            var third = char.Parse(Console.ReadLine());

            for (char c1 = first; c1 <= second; c1++)
            {
                for (char c2 = first; c2 <= second; c2++)
                {
                    for (char c3 = first; c3 <= second; c3++)
                    {
                        if (c1 != third && c2 != third && c3 != third)
                        {
                            Console.Write($"{c1}{c2}{c3} ");
                        }
                    }
                }
            }
        }
    }
}
