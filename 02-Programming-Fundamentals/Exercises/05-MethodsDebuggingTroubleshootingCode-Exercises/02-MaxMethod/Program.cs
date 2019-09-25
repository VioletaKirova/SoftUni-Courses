using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_MaxMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int currentMax = GetMax(a, b);
            int c = int.Parse(Console.ReadLine());
            int max = GetMax(currentMax, c);
            Console.WriteLine(max);
        }

        static int GetMax(int a, int b)
        {
            return Math.Max(a, b);
        }
    }
}
