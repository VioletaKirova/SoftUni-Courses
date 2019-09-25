using System;
using System.Collections.Generic;

namespace _04_MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                else if (input[i] == ')')
                {
                    int startingIndex = stack.Pop();
                    Console.WriteLine(input.Substring(startingIndex, i - startingIndex + 1));
                }
            }
        }
    }
}
