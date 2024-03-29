﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int start = 0;
            int len = 1;
            int maxStart = 0;
            int maxLen = 1;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == numbers[start])
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

            for (int i = maxStart; i < maxStart + maxLen; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
        }
    }
}
