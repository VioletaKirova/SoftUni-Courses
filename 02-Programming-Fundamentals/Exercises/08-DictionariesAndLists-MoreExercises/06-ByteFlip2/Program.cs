using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_ByteFlip2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> nums = Console.ReadLine().Split(' ').Where(x => x.Length == 2).Reverse().ToList();

            for (int i = 0; i < nums.Count; i++)
            {
                char[] charArr = nums[i].Reverse().ToArray();
                Console.Write(System.Convert.ToChar(System.Convert.ToUInt32(new string(charArr), 16)));
            }

            Console.WriteLine();
        }
    }
}