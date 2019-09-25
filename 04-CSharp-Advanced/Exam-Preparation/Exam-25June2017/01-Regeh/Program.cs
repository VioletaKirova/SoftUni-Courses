using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01_Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"\[[\w]+<([\d]+)REGEH([\d]+)>[\w]+\]";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            List<int> indexes = new List<int>();

            foreach (Match match in matches)
            {
                indexes.Add(int.Parse(match.Groups[1].ToString()));
                indexes.Add(int.Parse(match.Groups[2].ToString()));
            }

            int index = 0;

            string output = "";

            for (int i = 0; i < indexes.Count; i++)
            {
                index += indexes[i];
                index %= input.Length;
                output += input[index];
            }

            Console.WriteLine(output);
        }
    }
}
