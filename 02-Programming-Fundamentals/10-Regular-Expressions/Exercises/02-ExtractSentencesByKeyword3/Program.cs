using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02_ExtractSentencesByKeyword3
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            List<string> text = Console.ReadLine().Split('.', '!', '?').ToList();
            string regex = $@"\b{word}\b";

            for (int i = 0; i < text.Count; i++)
            {
                MatchCollection matches = Regex.Matches(text[i], regex);

                foreach (Match m in matches)
                {
                    if (m.Success == true)
                    {
                        Console.WriteLine(text[i].Trim());
                    }
                }
            }
        }
    }
}