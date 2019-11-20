using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_ByteFlip
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine()
                .Split(' ')
                .Where(x => x.Length == 2)
                .ToArray();

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                char[] charArray = nums[i].ToCharArray();
                Array.Reverse(charArray);
                Console.Write(System.Convert.ToChar(System.Convert.ToUInt32(new string(charArray), 16)));
            }

            Console.WriteLine();
        }
    }
}