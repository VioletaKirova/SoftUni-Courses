using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05_KeyReplacer
{
    // 83/100
    class Program
    {
        static void Main(string[] args)
        {
            string keyInput = Console.ReadLine();
            string text = Console.ReadLine();
            string regex = @"(\w+)([\|\\<])(.*?)(?!.*([\|\\<]))(\w+)";
            Match keyMatch = Regex.Match(keyInput, regex);
            string start = keyMatch.Groups[1].Value;
            string end = keyMatch.Groups[5].Value;
            string[] splitByStart = text.Split(new string[] {start}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string output = "";

            foreach (var word in splitByStart)
            {
                if (word.Contains(end))
                {
                    int endPosition = word.IndexOf(end);
                    output = new string(word.Substring(0, endPosition).ToArray());
                    Console.Write(output);
                }
            }

            if (output.Length != 0)
                Console.WriteLine();
            else
                Console.WriteLine("Empty result");
        }
    }
}