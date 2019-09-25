using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_MaxSequenceOfEqualElements2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> outputNums = new List<int>();
            int currentNum = nums[0];
            int currentLength = 1;
            int maxNum = nums[0];
            int maxLength = 1;

            for (int i = 0; i < nums.Count - 1; i++)
            {
                if (nums[i] == nums[i + 1])
                {
                    currentLength++;
                    currentNum = nums[i];

                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        maxNum = currentNum;
                    }

                }
                else
                {
                    currentLength = 1;
                }
            }

            for (int i = 0; i < maxLength; i++)
            {
                outputNums.Add(maxNum);
            }

            Console.WriteLine(string.Join(" ", outputNums));
        }
    }
}