using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03_Snowflake
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> allLines = new List<string>();

            for (int i = 0; i < 5; i++)
                allLines.Add(Console.ReadLine());

            string input = $@"{allLines[0]}
                              {allLines[1]}
                              {allLines[2]}
                              {allLines[3]}
                              {allLines[4]}";

            string pattern = @"[^A-Za-z\d]+
[\d_]+
([^A-Za-z\d]+)([\d_]+)(?<core>[a-zA-Z]+)([\d_]+)([^A-Za-z\d]+)
[\d_]+
[^A-Za-z\d]+";

            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                Console.WriteLine("Valid");
                Console.WriteLine(match.Groups["core"].Value.Length);
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        }
    }
}