using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03_RageQuit
{
    // 20/100
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToUpper();
            string output = "";
            string pattern = @"([^\d]+)([\d]+)";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            foreach (Match m in matches)
            {
                string str = m.Groups[1].Value;
                int count = int.Parse(m.Groups[2].Value);

                for (int i = 0; i < count; i++)
                    output += str;             
            }

            char[] uniqueSymbols = output.Distinct().ToArray();
            Console.WriteLine($"Unique symbols used: {uniqueSymbols.Length}");
            Console.WriteLine(output);
        }
    }
}