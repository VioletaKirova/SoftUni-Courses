using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03_Regexmon
{
    // 80/100
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string didimonPattern = @"[^a-zA-Z\-]+";
            string bojomonPattern = @"[a-zA-Z]+\-[a-zA-Z]+";

            for (int i = 0; i < text.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Match didimonMatch = Regex.Match(text, didimonPattern);

                    if (didimonMatch.Success)
                    {
                        string match = didimonMatch.Value;
                        Console.WriteLine(match);
                        int indexOfMatch = text.IndexOf(match);
                        text = text.Substring(indexOfMatch);
                    }
                    else
                        break;
                }
                else
                {
                    Match bojomonMatch = Regex.Match(text, bojomonPattern);

                    if (bojomonMatch.Success)
                    {
                        string match = bojomonMatch.Value;
                        Console.WriteLine(match);
                        int indexOfMatch = text.IndexOf(match);
                        text = text.Substring(indexOfMatch);
                    }
                    else
                        break;
                }
            }
        }
    }
}