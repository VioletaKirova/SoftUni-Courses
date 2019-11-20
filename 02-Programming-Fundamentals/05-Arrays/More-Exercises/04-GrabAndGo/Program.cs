using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_GrabAndGo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int num = int.Parse(Console.ReadLine());
            int numPosition = 0;
            long sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == num)
                {
                    numPosition = i;
                }
                else if (i == arr.Length - 1 && numPosition == 0)
                {
                    Console.WriteLine("No occurrences were found!");
                }
            }
            if (numPosition != 0)
            {
                for (int i = 0; i < numPosition; i++)
                {
                    sum += arr[i];
                }

                Console.WriteLine(sum);
            }
        }
    }
}