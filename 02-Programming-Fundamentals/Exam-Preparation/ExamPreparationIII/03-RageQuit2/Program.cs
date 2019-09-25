using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03_RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToUpper();
            StringBuilder output = new StringBuilder();
            string pattern = @"([^\d]+)([\d]+)";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            foreach (Match m in matches)
            {
                string str = m.Groups[1].Value;
                int count = int.Parse(m.Groups[2].Value);

                for (int i = 0; i < count; i++)
                    output.Append(str);
            }

            char[] uniqueSymbols = output.ToString().Distinct().ToArray();
            Console.WriteLine($"Unique symbols used: {uniqueSymbols.Length}");
            Console.WriteLine(output);
        }
    }
}