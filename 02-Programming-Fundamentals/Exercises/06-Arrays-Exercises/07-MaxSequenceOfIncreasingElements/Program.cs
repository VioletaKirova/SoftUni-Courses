using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_MaxSequenceOfIncreasingElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int start = 0;
            int current = 0;
            int length = 1;
            int maxStart = 0;
            int maxLength = 1;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > arr[current])
                {
                    current++;
                    length++;

                    if (length > maxLength)
                    {
                        maxLength = length;
                        maxStart = start;
                    }
                }
                else
                {
                    start = i;
                    current = i;
                    length = 1;
                }
            }
            for (int i = maxStart; i < maxStart + maxLength; i++)
            {
                Console.Write($"{arr[i]} ");
            }
        }
    }
}
