using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _07_QueryMess3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                string pattern = @"([^&?=\s]+)=([^&?=\s]+)";
                string spacesPattern = @"(%20|\+)+";

                MatchCollection matches = Regex.Matches(input, pattern);

                var matchesDict = new Dictionary<string, List<string>>();

                foreach (Match m in matches)
                {
                    string key = m.Groups[1].Value;
                    string value = m.Groups[2].Value;

                    Regex spacesRegex = new Regex(spacesPattern);
                    key = spacesRegex.Replace(key, " ").Trim();
                    value = spacesRegex.Replace(value, " ").Trim();

                    if (!matchesDict.ContainsKey(key))
                    {
                        matchesDict.Add(key, new List<string>());
                        matchesDict[key].Add(value);
                    }
                    else
                    {
                        matchesDict[key].Add(value);
                    }
                }

                foreach (var match in matchesDict)
                {
                    string value = string.Join(", ", match.Value);
                    Console.Write($"{match.Key}=[{value}]");                    
                }

                Console.WriteLine();

                input = Console.ReadLine();
            }
        }
    }
}