using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _07_QueryMess2
{
    // 83/100
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputArr = input.Split('&').ToArray();
                List<string> pairs = new List<string>();

                foreach (var p in inputArr)
                {
                    string pair = p;

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
                
                var pairKeysAndValues = new Dictionary<string, List<string>>();

                foreach (var pair in pairs)
                {
                    string[] splitPair = pair.Split('=').ToArray();
                    string key = splitPair[0].Trim();
                    string value = splitPair[1].Trim();
                    string keyPattern = @"([A-Za-z0-9]+?)(?!.*([A-Za-z0-9]+?))$";
                    string valuePattern = @"(.*[A-Za-z0-9])*";
                    Match matchKey = Regex.Match(key, keyPattern);
                    Match matchValue = Regex.Match(value, valuePattern);

                    if (matchKey.Success && matchValue.Success)
                    {
                        if (!pairKeysAndValues.ContainsKey(matchKey.Value))
                        {
                            pairKeysAndValues[matchKey.Value] = new List<string>();
                        }

                        pairKeysAndValues[matchKey.Value].Add(matchValue.Value);
                    }
                }               

                foreach (var pair in pairKeysAndValues)
                {
                    Console.Write(pair.Key + "=[" + string.Join(", ", pair.Value) + "]");
                }

                Console.WriteLine();
                input = Console.ReadLine();
            }
        }
    }
}