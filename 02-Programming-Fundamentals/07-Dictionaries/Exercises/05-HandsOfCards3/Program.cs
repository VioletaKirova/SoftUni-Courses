using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_HandsOfCards3
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, string>();

            for (int i = 0; ; i++)
            {
                string input = Console.ReadLine();

                if (input == "JOKER")
                    break;

                List<string> playerAndCards = input
                    .Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();            

                if (!dict.ContainsKey(playerAndCards[0]))
                    dict[playerAndCards[0]] = playerAndCards[1];
                else
                    dict[playerAndCards[0]] += playerAndCards[1];
            }

            var results = new Dictionary<string, int>();

            foreach (var player in dict)
            {
                List<string> cards = player.Value
                                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Distinct()
                                    .ToList();

                int finalResult = 0;

                for (int i = 0; i < cards.Count; i++)
                {
                    var result = 1;

                    foreach (var c in cards[i])
                    {
                        switch (c)
                        {
                            case '0': result *= 10; break;
                            case '1': result *= 1; break;
                            case '2': result *= 2; break;
                            case '3': result *= 3; break;
                            case '4': result *= 4; break;
                            case '5': result *= 5; break;
                            case '6': result *= 6; break;
                            case '7': result *= 7; break;
                            case '8': result *= 8; break;
                            case '9': result *= 9; break;
                            case 'J': result *= 11; break;
                            case 'Q': result *= 12; break;
                            case 'K': result *= 13; break;
                            case 'A': result *= 14; break;
                            case 'S': result *= 4; break;
                            case 'H': result *= 3; break;
                            case 'D': result *= 2; break;
                            case 'C': result *= 1; break;
                            default:
                                break;
                        }
                    }

                    finalResult += result;
                }

                results[player.Key] = finalResult;
            }
                          
            foreach (var p in results)
            {
                Console.WriteLine($"{p.Key}: {p.Value}");
            }
        }
    }
}