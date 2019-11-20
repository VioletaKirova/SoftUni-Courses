using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace _07_TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] inputArr = input.ToCharArray();

            List<int> nums = new List<int>();
            List<char> chars = new List<char>();

            for (int i = 0; i < inputArr.Length; i++)
            {
                if (char.IsNumber(inputArr[i]))
                    nums.Add(int.Parse(inputArr[i].ToString()));
                else
                    chars.Add(inputArr[i]);
            }

            List<int> take = new List<int>();
            List<int> skip = new List<int>();

            for (int i = 0; i < nums.Count; i++)
            {
                if (i % 2 == 0)
                    take.Add(nums[i]);
                else
                    skip.Add(nums[i]);
            }

            string result = "";
            int skipTotal = 0;

            for (int i = 0; i < skip.Count; i++)
            {
                result += string.Concat(chars.Skip(skipTotal).Take(take[i]));
                skipTotal += take[i] + skip[i];
            }

            Console.WriteLine(result);
        }
    }
}