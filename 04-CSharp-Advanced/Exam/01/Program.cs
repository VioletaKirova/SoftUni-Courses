using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> lines = new List<string>();

            for (int i = 0; i < n; i++)
            {
                lines.Add(Console.ReadLine());
            }

            string quoteMark = "\"";

            string linePattern = @"s:([^;]+);r:([^;]+);m--" + quoteMark + @"([a-zA-Z ]+)" + quoteMark;
            Regex lineRegex = new Regex(linePattern);

            string digitPattern = @"[0-9]";
            Regex digitRegex = new Regex(digitPattern);

            string namePattern = @"[a-zA-Z ]*";
            Regex nameRegex = new Regex(namePattern);

            int data = 0;

            foreach (var line in lines)
            {
                MatchCollection matches = lineRegex.Matches(line);

                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        string sender = match.Groups[1].Value;
                        string receiver = match.Groups[2].Value;
                        string message = match.Groups[3].Value;

                        string digitStr = sender + receiver;
                        MatchCollection digits = digitRegex.Matches(digitStr);

                        foreach (Match digit in digits)
                        {
                            data += int.Parse(digit.Value);
                        }

                        MatchCollection senderNameSymbols = nameRegex.Matches(sender);
                        StringBuilder senderName = new StringBuilder();

                        foreach (Match symbol in senderNameSymbols)
                        {
                            senderName.Append(symbol);
                        }

                        string senderNameStr = senderName.ToString();

                        MatchCollection receiverNameSymbols = nameRegex.Matches(receiver);
                        StringBuilder receiverName = new StringBuilder();

                        foreach (Match symbol in receiverNameSymbols)
                        {
                            receiverName.Append(symbol);
                        }

                        string receiverNameStr = receiverName.ToString();

                        Console.WriteLine($"{senderNameStr} says \"{message}\" to {receiverNameStr}");
                    }
                }
            }

            Console.WriteLine($"Total data transferred: {data}MB");
        }
    }
}
