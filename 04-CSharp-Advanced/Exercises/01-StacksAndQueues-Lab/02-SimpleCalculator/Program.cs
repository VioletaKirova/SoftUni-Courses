using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            Stack<string> stack = new Stack<string>(input.Reverse());

            while (stack.Count > 1)
            {
                int leftOperand = int.Parse(stack.Pop());
                string operation = stack.Pop();
                int rightOperand = int.Parse(stack.Pop());

                if(operation == "+")
                {
                    stack.Push((leftOperand + rightOperand).ToString());
                }
                else
                {
                    stack.Push((leftOperand - rightOperand).ToString());
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
