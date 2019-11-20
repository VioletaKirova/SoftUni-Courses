using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_SumReversedNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> nums = Console.ReadLine().Split(' ').ToList();
            List<int> reversedNums = new List<int>(nums.Count);

            for (int i = 0; i < nums.Count; i++)
            {
                char[] element = nums[i].ToArray();
                char[] reversed = element.Reverse().ToArray();
                reversedNums.Add(int.Parse(string.Join("", reversed)));
            }

            Console.WriteLine(reversedNums.Sum());
        }
    }
}