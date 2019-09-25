using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03_TicketTrouble
{
    // 83/100

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string text = Console.ReadLine();

            string regexPattern1 = @"{([^{}\[\]]*)\[" + $"{input}" + @"\]([^{}\[\]]*)\[([A-Z][0-9]{1,2})\]([^{}\[\]]*)}";
            string regexPattern2 = @"\[([^{}\[\]]*){" + $"{input}" + @"}([^{}\[\]]*){([A-Z][0-9]{1,2})}([^{}\[\]]*)\]";

            Regex regex1 = new Regex(regexPattern1);
            Regex regex2 = new Regex(regexPattern2);

            MatchCollection regex1Matches = regex1.Matches(text);
            MatchCollection regex2Matches = regex2.Matches(text);

            List<string> seats = new List<string>();

            foreach (Match match in regex1Matches)
            {
                seats.Add($"{match.Groups[3]}");
            }

            foreach (Match match in regex2Matches)
            {
                seats.Add($"{match.Groups[3]}");
            }

            if (seats.Count == 2)
            {
                Console.WriteLine($"You are traveling to {input} on seats {seats[0]} and {seats[1]}.");
            }
            else
            {
                for (int i = 0; i < seats.Count - 1; i++)
                {
                    for (int j = i + 1; j < seats.Count; j++)
                    {
                        if (seats[i].Substring(1) == seats[j].Substring(1))
                        {
                            Console.WriteLine($"You are traveling to {input} on seats {seats[i]} and {seats[j]}.");
                        }
                    }
                }
            }
        }
    }
}
