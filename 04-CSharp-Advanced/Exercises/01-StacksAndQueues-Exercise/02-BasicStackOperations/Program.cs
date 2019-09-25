using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            int numsToPush = int.Parse(input[0]);
            int numsToPop = int.Parse(input[1]);
            int element = int.Parse(input[2]);

            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Stack<int> numsStack = new Stack<int>();

            int pushLength = Math.Min(nums.Length, numsToPush);

            for (int i = 0; i < pushLength; i++)
            {
                numsStack.Push(nums[i]);
            }

            int popLength = Math.Min(numsStack.Count, numsToPop);

            for (int i = 0; i < popLength; i++)
            {
                numsStack.Pop();
            }

            List<int> numsList = numsStack.ToList().OrderBy(x => x).ToList();

            if (numsList.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (numsList.Contains(element))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numsList.First());
            }
        }
    }
}
