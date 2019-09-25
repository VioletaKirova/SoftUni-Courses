using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03_AnonymousVox
{
    class Program
    {
        static void Main(string[] args)
        {
            string encodedText = Console.ReadLine();
            string[] values = Console.ReadLine().Split(new char[] {'{', '}'}, StringSplitOptions.RemoveEmptyEntries).ToArray();

            string pattern = @"([A-Za-z]+)([\S]+)(\1)";
            MatchCollection matches = Regex.Matches(encodedText, pattern);
            List<string> matchList = new List<string>();

            foreach (Match m in matches)
            {
                matchList.Add(m.Groups[2].Value);
            }

            for (int i = 0; i < matchList.Count; i++)
            {
                int valueIndex = encodedText.IndexOf(matchList[i]);
                encodedText = encodedText.Insert(valueIndex, values[i]);
                encodedText = encodedText.Remove(valueIndex + values[i].Length, matchList[i].Length);
            }

            Console.WriteLine(encodedText);
        }
    }
}