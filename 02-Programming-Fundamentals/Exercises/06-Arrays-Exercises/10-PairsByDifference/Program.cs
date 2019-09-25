using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_PairsByDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());
            int count = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = arr.Length - 1; j > i; j--)
                {
                    if (Math.Abs(arr[i] - arr[j]) == n)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
