using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04_WinningTicket
{
    // 70/100
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex spacesRegex = new Regex(@"\s+");
            string inputWithoutSpaces = spacesRegex.Replace(input, "");
            string[] tickets = inputWithoutSpaces.Split(',').ToArray();

            Regex validRegex = new Regex(@"^([^@#$\^]*)(?<symbols>[@#\$\^]{6,9})([^@#$\^]*)(\k'symbols')([^@#$\^]*)");
            Regex jackpotRegex = new Regex(@"^(?<symbols>[@#$\^]{10})(\k'symbols')$");

            for (int i = 0; i < tickets.Length; i++)
            {
                string currentTicket = tickets[i];

                if (currentTicket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                Match valid = validRegex.Match(currentTicket);
                Match jackpot = jackpotRegex.Match(currentTicket);

                if (jackpot.Success)
                    Console.WriteLine($"ticket \"{currentTicket}\" - 10{valid.Groups["symbols"].Value.First()} Jackpot!");
                else if (valid.Success)        
                    Console.WriteLine($"ticket \"{currentTicket}\" - {valid.Groups["symbols"].Length}{valid.Groups["symbols"].Value.First()}");               
                else
                    Console.WriteLine($"ticket \"{currentTicket}\" - no match");
            }
        }
    }
}