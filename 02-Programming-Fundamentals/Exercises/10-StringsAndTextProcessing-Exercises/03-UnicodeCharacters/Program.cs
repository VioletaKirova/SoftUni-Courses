using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_UnicodeCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToArray();
            string unicode = "";
            string output = "";

            for (int i = 0; i < input.Length; i++)
            {
                unicode = "\\u" + ((int)input[i]).ToString("x4");
                //unicode = "\\u" + ((int)input[i]).ToString("x").PadLeft(4, '0');

                output += unicode;
            }

            Console.WriteLine(output);
        }
    }
}