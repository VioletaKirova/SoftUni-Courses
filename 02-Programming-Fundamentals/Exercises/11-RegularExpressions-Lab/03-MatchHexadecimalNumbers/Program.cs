using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03_MatchHexadecimalNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\b(?:0x)?[A-F0-9]+\b";
            string numbers = Console.ReadLine();
            MatchCollection matchedNums = Regex.Matches(numbers, regex);
            string[] matchedNumsArr = matchedNums
                .Cast<Match>()
                .Select(a => a.Value)
                .ToArray();
            Console.WriteLine(string.Join(" ", matchedNumsArr));
        }
    }
}