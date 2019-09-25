using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03_CryptoBlockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            string text = "";

            for (int i = 0; i < rows; i++)
            {
                text += Console.ReadLine();
            }

            string pattern = @"([\[{])([\x20-\x7E]*?)([0-9]{3,})([\x20-\x7E]*?)([\]}])";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            List<int> values = new List<int>();

            foreach (Match match in matches)
            {
                string currentMatch = match.Value.ToString();

                char firstElement = currentMatch[0];
                char lastElement = currentMatch[currentMatch.Length - 1];

                if ((firstElement == '{' && lastElement != '}') ||
                    (firstElement == '[' && lastElement != ']'))
                {
                    continue;
                }

                if (match.Groups[3].Length % 3 != 0)
                {
                    continue;
                }

                string digits = match.Groups[3].ToString();

                for (int i = 0; i < digits.Length - 2; i += 3)
                {
                    char[] chars = new char[3];

                    chars[0] = digits[i];
                    chars[1] = digits[i + 1];
                    chars[2] = digits[i + 2];

                    int currentNum = Math.Abs(int.Parse(string.Join("", chars)) - currentMatch.Length);

                    values.Add(currentNum);
                }
            }

            foreach (var number in values)
            {
                Console.Write((char)number);
            }

            Console.WriteLine();
        }
    }
}
