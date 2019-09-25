using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_MagicExchangeableWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            char[] str1 = input[0].Distinct().ToArray();
            char[] str2 = input[1].Distinct().ToArray();

            if (str1.Length == str2.Length)
                Console.WriteLine("true");
            else
                Console.WriteLine("false");
        }
    }
}