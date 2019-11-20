using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            char[] str1 = input[0].ToCharArray();
            char[] str2 = input[1].ToCharArray();

            int shorterArrLen = Math.Min(str1.Length, str2.Length);
            int longerArrLen = Math.Max(str1.Length, str2.Length);
            int output = 0;

            for (int i = 0; i < shorterArrLen; i++)
                output += (int)str1[i] * (int)str2[i];
         
            if (str1.Length != str2.Length)
            {
                int diff = longerArrLen - shorterArrLen;
                char[] longerArrExtraChars = new char[diff];

                if (str1.Length > str2.Length)
                    longerArrExtraChars = str1.Reverse().Take(diff).ToArray();
                else if (str2.Length > str1.Length)
                    longerArrExtraChars = str2.Reverse().Take(diff).ToArray();

                for (int i = 0; i < diff; i++)
                    output += (int)longerArrExtraChars[i];
            }

            Console.WriteLine(output);
        }
    }
}