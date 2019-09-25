using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02_ExtractSentencesByKeyword
{
    // 80/100
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();
            string regex = $@"(^|(?<=\s))([A-Z]([A-Za-z]+)?)((\s([A-Za-z0-9,\-]+))+)?\s{word}((\s([A-Za-z0-9,\-]+))+)([\.!\?])($|\b|(?=\s))";
            string text = Console.ReadLine();
            MatchCollection matches = Regex.Matches(text, regex);
            List<string> sentences = new List<string>();

            foreach (Match m in matches)
            {
                sentences.Add(m.Value.Remove(m.Value.Length - 1));
            }

            foreach (var s in sentences)
            {
                Console.WriteLine(s);
            }
        }
    }
}