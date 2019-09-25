using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> output = new List<int>();
            int currentNum = nums[0];
            int currentLength = 1;
            int number = nums[0];
            int bestLength = 1;

            if (nums.Count > 0)
            {
                for (int i = 1; i < nums.Count; i++)
                {
                    if (nums.Count == 1)
                    {
                        number = nums[0];
                    }

                    if (nums[i] == nums[i - 1])
                    {
                        currentNum = nums[i];
                        currentLength++;
                    }
                    else
                    {
                        currentNum = nums[i];
                        currentLength = 1;
                    }

                    if (currentLength > bestLength)
                    {
                        number = currentNum;
                        bestLength = currentLength;
                    }
                }

                for (int i = 0; i < bestLength; i++)
                {
                    output.Add(number);
                }

                Console.WriteLine(string.Join(" ", output));
            }
        }
    }
}