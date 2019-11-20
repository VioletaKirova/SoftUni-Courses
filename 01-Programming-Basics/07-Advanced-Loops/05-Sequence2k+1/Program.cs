using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Sequence2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int num = 1;

            for (int i = 0; num <= n; i++)
            {
                Console.WriteLine(num);
                num = num * 2 + 1;
            }
        }
    }
}
