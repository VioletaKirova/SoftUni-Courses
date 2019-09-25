using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_MultiplicationTable2
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            var times = int.Parse(Console.ReadLine());

            if (times < 10)
            {
                for (int i = times; i <= 10; i++)
                {
                    Console.WriteLine($"{num} X {i} = {num * i}");
                }
            }
            else
            {
                Console.WriteLine($"{num} X {times} = {num * times}");
            }
        }
    }
}
