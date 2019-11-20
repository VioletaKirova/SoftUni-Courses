using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02_MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"(\+359([ |-])2(\2)(\d{3})(\2)(\d{4}))\b";
            string phoneNums = Console.ReadLine();
            MatchCollection matches = Regex.Matches(phoneNums, regex);
            string[] matchedPhones = matches
                .Cast<Match>()
                .Select(a => a.Value.Trim())
                .ToArray();
            Console.WriteLine(string.Join(", ", matchedPhones));
        }
    }
}