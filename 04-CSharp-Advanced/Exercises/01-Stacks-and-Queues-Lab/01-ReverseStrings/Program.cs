using System;
using System.Collections;
using System.Collections.Generic;

namespace _01_ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>(input);

            while(stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
