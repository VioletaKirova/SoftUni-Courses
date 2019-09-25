﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_CountNumbers
{
    // 83/100
    class Program
    {
        static void Main(string[] args)
        {          
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            nums.Sort();
            nums.Add(0);

            int count = 1;

            for (int i = 0; i < nums.Count; i++)
            {
                for (int j = i + 1; j < nums.Count; j++)
                {
                    if (nums[i] == nums[j])
                    {
                        count++;
                        nums.RemoveAt(j);
                        j--;
                    }

                    if (j == nums.Count - 1)
                    {
                        Console.WriteLine($"{nums[i]} -> {count}");
                        count = 1;
                    }
                }
            }
        }
    }
}