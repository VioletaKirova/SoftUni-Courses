using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_MaximumElement4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            Stack<int> maxStack = new Stack<int>();

            maxStack.Push(int.MinValue);

            for (int i = 0; i < n; i++)
            {
                int[] command = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                switch (command[0])
                {
                    case 1:
                        int element = command[1];

                        stack.Push(element);

                        if (maxStack.Peek() < element)
                        {
                            maxStack.Push(element);
                        }

                        break;
                    case 2:
                        int deletedElement = stack.Pop();

                        if (deletedElement == maxStack.Peek())
                        {
                            maxStack.Pop();
                        }

                        break;
                    case 3:
                        Console.WriteLine(maxStack.Peek());

                        break;
                }
            }
        }
    }
}
