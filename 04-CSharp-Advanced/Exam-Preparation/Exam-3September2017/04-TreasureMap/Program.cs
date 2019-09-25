using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _04_TreasureMap
{
    // 42/100

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> text = new List<string>();

            string pattern = @"(#|!)[^#!]*?\b([A-Za-z]{4})\b[^#!]*(\d{3})-(\d{6}|\d{4})[^#!]*?(?!\1)(#|!)";
            Regex regex = new Regex(pattern);

            for (int i = 0; i < n; i++)
            {
                text.Add(Console.ReadLine());
            }

            for (int i = 0; i < text.Count; i++)
            {
                MatchCollection matches = regex.Matches(text[i]);

                if (matches.Count > 0)
                {
                    int indexOfNeededMatch = matches.Count / 2;

                    string addressName = matches[indexOfNeededMatch].Groups[2].ToString();
                    string streetNumber = matches[indexOfNeededMatch].Groups[3].ToString();
                    string password = matches[indexOfNeededMatch].Groups[4].ToString();

                    Console.WriteLine($"Go to str. {addressName} {streetNumber}. Secret pass: {password}.");
                }               
            }
        }
    }
}
