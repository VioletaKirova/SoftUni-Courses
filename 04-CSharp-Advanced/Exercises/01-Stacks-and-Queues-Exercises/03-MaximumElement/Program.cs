using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_MaximumElement
{
    // 75/100

    class Program
    {       
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            string command = "";

            for (int i = 0; i < n; i++)
            {
                command = Console.ReadLine();

                if (command.StartsWith("1"))
                {
                    string[] input = command.Split(' ');

                    int number = int.Parse(input[1]);

                    stack.Push(number);
                }
                else if (command.StartsWith("2"))
                {
                    stack.Pop();
                }
                else if (command.StartsWith("3"))
                {
                    int[] arr = stack.ToArray().OrderByDescending(x => x).ToArray();

                    Console.WriteLine(arr[0]);
                }
            }
        }
    }
}
