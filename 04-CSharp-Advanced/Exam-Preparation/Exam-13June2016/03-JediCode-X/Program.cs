using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace _03_JediCode_X
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder input = new StringBuilder();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                input.Append(Console.ReadLine());
            }

            string namesInputPat = Console.ReadLine();
            string messagesInputPat = Console.ReadLine();

            string namesPattern = namesInputPat + @"([a-zA-Z]{" + namesInputPat.Length + @"})(?![a-zA-Z])";
            string messgesPattern = messagesInputPat + @"([a-zA-Z0-9]{" + messagesInputPat.Length + @"})(?![a-zA-Z0-9])";

            List<string> nameMatches = new List<string>();
            List<string> messageMatches = new List<string>();

            Regex nameRegex = new Regex(namesPattern);
            Regex messageRegex = new Regex(messgesPattern);

            MatchCollection names = nameRegex.Matches(input.ToString());
            MatchCollection messages = messageRegex.Matches(input.ToString());

            if (names.Count > 0)
            {
                foreach (Match name in names)
                {
                    nameMatches.Add(name.Groups[1].Value);
                }
            }

            if (messages.Count > 0)
            {
                foreach (Match message in messages)
                {
                    messageMatches.Add(message.Groups[1].Value);
                }
            }

            int[] indexes = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<string> validMessages = new List<string>();
            validMessages.AddRange(messageMatches);

            for (int i = 0; i < nameMatches.Count; i++)
            {
                string currentJedi = nameMatches[i];

                if (i < indexes.Length)
                {
                    int currentIndex = indexes[i] - 1;

                    if (currentIndex >= 0 && currentIndex < messageMatches.Count)
                    {
                        Console.WriteLine($"{currentJedi} - {messageMatches[currentIndex]}");
                        validMessages[currentIndex] = int.MinValue.ToString();
                    }
                    else
                    {
                        currentIndex = 0;

                        while (validMessages[currentIndex] == int.MinValue.ToString())
                        {
                            currentIndex++;

                            if (currentIndex == validMessages.Count)
                            {
                                break;
                            }
                        }

                        if (currentIndex < validMessages.Count)
                        {
                            validMessages[currentIndex] = int.MinValue.ToString();

                            Console.WriteLine($"{currentJedi} - {messageMatches[currentIndex]}");
                        }
                    }
                }               
            }
        }
    }
}
