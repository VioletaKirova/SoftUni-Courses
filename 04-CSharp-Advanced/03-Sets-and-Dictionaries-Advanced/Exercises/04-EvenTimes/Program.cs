﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(number))
                {
                    numbers[number] = 0;
                }

                numbers[number]++;
            }

            Console.WriteLine(numbers.Where(num => num.Value % 2 == 0).FirstOrDefault().Key);
        }
    }
}
