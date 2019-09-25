using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03_CubicMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> output = new List<string>();

            string pattern = @"^([0-9]+)([a-zA-Z]+)([^a-zA-Z]*)$";
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();

            while (input != "Over!")
            {
                int length = int.Parse(Console.ReadLine());

                if (regex.IsMatch(input))
                {
                    Match currentMatch = regex.Match(input);
                    string message = currentMatch.Groups[2].ToString();

                    if (message.Length == length)
                    {
                        List<int> indexes = new List<int>();

                        string indexesStr = currentMatch.Groups[1].ToString() + currentMatch.Groups[3].ToString();

                        string indexesPattern = @"[0-9]";
                        Regex indexesRegex = new Regex(indexesPattern);
                        MatchCollection matches = indexesRegex.Matches(indexesStr);

                        string verificationCode = "";

                        foreach (Match match in matches)
                        {
                            int currentIndex = int.Parse(match.ToString());

                            if (currentIndex >= 0 && currentIndex < message.Length)
                            {
                                verificationCode += message[currentIndex];
                            }
                            else
                            {
                                verificationCode += " ";
                            }
                        }

                        output.Add(message + " == " + verificationCode);
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var message in output)
            {
                Console.WriteLine(message);
            }
        }
    }
}
