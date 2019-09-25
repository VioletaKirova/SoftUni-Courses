using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05_MatchNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))";
            string numsStr = Console.ReadLine();
            MatchCollection matchedNums = Regex.Matches(numsStr, regex);

            foreach (Match num in matchedNums)
            {
                Console.Write($"{num.Value} ");
            }

            Console.WriteLine();
        }
    }
}