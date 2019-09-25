using System;
using System.Collections.Generic;
using System.Linq;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            int dnaLength = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "Clone them!")
            {
                int[] sequence = input.Split(new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int start = -1;
                int len = 1;
                int maxStart = 0;
                int maxLen = 1;

                for (int i = 1; i < sequence.Length; i++)
                {
                    if (sequence[i] == 1)
                    {
                        start = i;
                    }

                    if (sequence[i] == sequence[start])
                    {
                        len++;

                        if (len > maxLen)
                        {
                            maxLen = len;
                            maxStart = start;
                        }
                    }
                    else
                    {
                        start = i;
                        len = 1;
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}