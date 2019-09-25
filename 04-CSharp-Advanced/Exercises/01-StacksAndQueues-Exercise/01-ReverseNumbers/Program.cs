using System;
using System.Collections.Generic;

namespace _01_ReverseNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');

            Stack<string> stack = new Stack<string>(nums);

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop() + " ");
            }
        }
    }
}
