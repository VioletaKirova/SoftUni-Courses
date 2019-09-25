using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05_KeyReplacer2
{
    class Program
    {
        static void Main(string[] args)
        {
            string keyInput = Console.ReadLine();
            string text = Console.ReadLine();
            string regex = @"(\w+)([\|\\<])(.*?)(?!.*([\|\\<]))(\w+)";
            Match keyMatch = Regex.Match(keyInput, regex);
            string start = keyMatch.Groups[1].Value;
            string end = keyMatch.Groups[5].Value;
            string keyRegex = $@"({start})(.*?)({end})";
            MatchCollection keysFound = Regex.Matches(text, keyRegex);
            string result = "";

            foreach (Match match in keysFound)
            {
                result += $"{match.Groups[2].Value}";
            }

            if (result.Length == 0)
            {
                Console.WriteLine("Empty result");
            }
            else
            {
                Console.WriteLine(result);
            }
        }
    }
}