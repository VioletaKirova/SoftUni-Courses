using System;
using System.Collections.Generic;

namespace _03_DecimalToBinaryConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            Stack<int> binaryNum = new Stack<int>();

            if (input == 0)
            {
                Console.WriteLine(0);
                return;
            }
            else
            {
                while (input > 0)
                {
                    binaryNum.Push(input % 2);
                    input /= 2;
                }
            }

            while (binaryNum.Count > 0)
            {
                Console.Write(binaryNum.Pop());
            }
        }
    }
}
