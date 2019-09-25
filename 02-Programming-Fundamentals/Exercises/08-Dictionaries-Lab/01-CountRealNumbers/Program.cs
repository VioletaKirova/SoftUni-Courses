using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> nums = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            SortedDictionary<double, int> dict = new SortedDictionary<double, int>();

            foreach (var num in nums)
            {
                if (dict.ContainsKey(num))
                    dict[num]++;
                else
                    dict[num] = 1;
            }

            foreach (var item in dict)
            {
                Console.WriteLine(item.Key + " -> " + item.Value);
            }
        }
    }
}