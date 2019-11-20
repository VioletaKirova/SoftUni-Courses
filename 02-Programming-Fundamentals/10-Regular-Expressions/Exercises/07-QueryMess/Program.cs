using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _07_QueryMess
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputArr = input.Split('&').ToArray();
                List<string> pairs = new List<string>();

                foreach (var item in inputArr)
                {
                    string pair = item;

                    if (pair.Contains("%20") || pair.Contains("+"))
                    {
                        string spacePattern = @"(%20)|\+";
                        Regex spaceRegex = new Regex(spacePattern);
                        pair = spaceRegex.Replace(pair, " ");
                        string extraSpacesPattern = @"\s+";
                        Regex extraSpacesRegex = new Regex(extraSpacesPattern);
                        pair = extraSpacesRegex.Replace(pair, " ");
                    }

                    pairs.Add(pair);
                }
                
                string pattern = @"[A-Za-z0-9]+(=)(.*[A-Za-z0-9])*";
                List<string> matchedPairs = new List<string>();

                foreach (var pair in pairs)
                {
                    Match match = Regex.Match(pair, pattern);

                    if (match.Success)
                    {
                        matchedPairs.Add(match.Value);
                    }
                }

                var pairKeysAndValues = new Dictionary<string, List<string>>();

                foreach (var pair in matchedPairs)
                {
                    string[] pairParts = pair.Split('=').ToArray();
                    string key = pairParts[0].Trim();
                    string value = pairParts[1].Trim();

                    if (!pairKeysAndValues.ContainsKey(key))
                    {
                        pairKeysAndValues[key] = new List<string>();
                    }

                    pairKeysAndValues[key].Add(value);
                }

                foreach (var pair in pairKeysAndValues)
                {
                    Console.Write(pair.Key + "=[" + string.Join(", ", pair.Value) +"]" );                 
                }

                Console.WriteLine();          
                input = Console.ReadLine();
            }
        }
    }
}