using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            char[] strArr = str.Reverse().ToArray();
            Console.WriteLine(string.Join("", strArr));
        }
    }
}