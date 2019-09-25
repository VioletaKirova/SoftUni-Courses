using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int oneLevaCount = int.Parse(Console.ReadLine());
            int twoLevaCount = int.Parse(Console.ReadLine());
            int fiveLevaCount = int.Parse(Console.ReadLine());
            int sum = int.Parse(Console.ReadLine());

            for (int i1 = 0; i1 <= oneLevaCount; i1++)
            {
                for (int i2 = 0; i2 <= twoLevaCount; i2++)
                {
                    for (int i5 = 0; i5 <= fiveLevaCount; i5++)
                    {
                        if (i1 * 1 + i2 * 2 + i5 * 5 == sum)
                        {
                            Console.WriteLine($"{i1} * 1 lv. + {i2} * 2 lv. + {i5} * 5 lv. = {sum} lv.");
                        }
                    }
                }
            }
        }
    }
}
