using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int numsToAdd = input[0];
            int numsToRemove = input[1];
            int element = input[2];

            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>();

            int enqueueLen = Math.Min(numbers.Length, numsToAdd);

            for (int i = 0; i < enqueueLen; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            int dequeueLen = Math.Min(queue.Count, numsToRemove);

            for (int i = 0; i < dequeueLen; i++)
            {
                queue.Dequeue();
            }

            if(queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                if (queue.Contains(element))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
        }
    }
}
