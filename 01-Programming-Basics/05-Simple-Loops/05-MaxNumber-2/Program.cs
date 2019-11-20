using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_MaxNumber_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int maxValue = int.Parse(Console.ReadLine());

            for (int i = 0; i < n - 1; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());

                if (currentNum > maxValue)
                {
                    maxValue = currentNum;
                }
            }

            Console.WriteLine(maxValue);
        }
    }
}
