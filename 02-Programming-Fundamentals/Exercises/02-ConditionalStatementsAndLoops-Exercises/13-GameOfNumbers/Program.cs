using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_GameOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());
            var magicNum = int.Parse(Console.ReadLine());

            var start = Math.Min(n, m);
            var end = Math.Max(n, m);

            var count = 0;
            bool magicNumFound = false;

            var first = 0;
            var second = 0;

            for (int i = start; i <= end; i++)
            {
                for (int h = start; h <= end; h++)
                {
                    count++;

                    if ((i + h) == magicNum)
                    {
                        first = i;
                        second = h;

                        magicNumFound = true;
                    }
                }
            }

            if (magicNumFound)
            {
                Console.WriteLine($"Number found! {first} + {second} = {magicNum}");
            }
            else
            {
                Console.WriteLine($"{count} combinations - neither equals {magicNum}");
            }
        }
    }
}
