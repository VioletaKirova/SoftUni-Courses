using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04_WinningTicket3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();

            string[] symbols = new string[] {"@", "#", "\\$", "\\^"};

            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                bool winning = false;
                string leftPart = new string(ticket.Take(10).ToArray());
                string rightPart = new string(ticket.Skip(10).ToArray());

                foreach (var s in symbols)
                {
                    Regex regex = new Regex($@"{s}{{6,}}");

                    Match leftMatch = regex.Match(leftPart);
                    Match rightMatch = regex.Match(rightPart);

                    if (leftMatch.Success && rightMatch.Success)
                    {
                        winning = true;

                        int lenght = Math.Min(leftMatch.Value.Count(), rightMatch.Value.Count());

                        if (lenght == 10)
                            Console.WriteLine($"ticket \"{ticket}\" - 10{leftMatch.Value.First()} Jackpot!");
                        else
                            Console.WriteLine($"ticket \"{ticket}\" - {lenght}{leftMatch.Value.First()}");
                        break;
                    }                   
                }

                if (!winning)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }
            }
            
        }
    }
}