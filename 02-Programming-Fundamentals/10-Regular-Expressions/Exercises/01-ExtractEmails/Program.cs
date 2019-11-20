using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01_ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"(^|(?<=\s))([a-zA-Z0-9]+)([\.\-_]+)?([a-zA-Z0-9]+)(@)([a-zA-Z0-9]+)([a-zA-Z]+)(([\.\-])([a-zA-Z]+))+(\b|(?=\s))";
            string input = Console.ReadLine();
            MatchCollection emails = Regex.Matches(input, regex);

            foreach (Match email in emails)
            {
                Console.WriteLine(email.Value);
            }
        }
    }
}