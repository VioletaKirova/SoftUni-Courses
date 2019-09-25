using System;
using System.Collections.Generic;

namespace _09_StackFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<long> fibonacciStack = new Stack<long>();

            fibonacciStack.Push(0);
            fibonacciStack.Push(1);

            for (int i = 0; i < n - 1; i++)
            {
                long lastNum = fibonacciStack.Pop();
                long previousNum = fibonacciStack.Peek();
                long currentNum = lastNum + previousNum;

                fibonacciStack.Push(lastNum);
                fibonacciStack.Push(currentNum);
            }

            Console.WriteLine(fibonacciStack.Peek());
        }
    }
}
