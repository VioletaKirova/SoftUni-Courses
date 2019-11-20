using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ReverseArrayOfIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] intArr = new int[n];

            for (int i = 0; i < n; i++)
            {
                intArr[i] = int.Parse(Console.ReadLine());
            }

            for (int i = n-1; i >= 0; i--)
            {
                Console.Write($"{intArr[i]} ");
            }
        }
    }
}
