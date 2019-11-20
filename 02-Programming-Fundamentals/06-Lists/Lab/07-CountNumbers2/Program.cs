using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_CountNumbers2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            nums.Sort();
            nums.Add(0);

            int count = 1;

            for (int i = 0; i < nums.Count - 1; i++)
            {
                if (nums[i] == nums[i + 1])
                {
                    count++;
                }

                if (nums[i] != nums[i + 1] || nums[i] == nums.Count - 2)
                {
                    Console.WriteLine($"{nums[i]} -> {count}");
                    count = 1;
                }
            }
        }
    }
}