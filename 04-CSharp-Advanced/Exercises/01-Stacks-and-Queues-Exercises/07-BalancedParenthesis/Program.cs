using System;
using System.Collections.Generic;

namespace _07_BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            bool match = true;

            foreach (var symbol in input)
            {
                switch (symbol)
                {
                    case '{':
                    case '[':
                    case '(':
                        stack.Push(symbol);
                        break;
                    case '}':
                        if (stack.Count == 0 || stack.Pop() != '{')
                        {
                            match = false;
                        }
                        break;
                    case ']':
                        if (stack.Count == 0 || stack.Pop() != '[')
                        {
                            match = false;
                        }
                        break;
                    case ')':
                        if (stack.Count == 0 || stack.Pop() != '(')
                        {
                            match = false;
                        }
                        break;
                }

                if(!match)
                {
                    break;
                }
            }

            if (match)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
