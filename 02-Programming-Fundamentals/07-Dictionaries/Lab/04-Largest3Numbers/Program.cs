using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> largestNums = nums.OrderBy(n => -n).Take(3).ToList();
            Console.WriteLine(string.Join(" ", largestNums));
        }
    }
}