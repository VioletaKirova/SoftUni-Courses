using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02_HornetComm
{
    // 90/100
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var messagesDict = new Dictionary<string, List<string>>();
            var broadcastsDict = new Dictionary<string, List<string>>();

            while (input != "Hornet is Green")
            {
                string messagePattern = @"^([0-9]+)( <-> )([0-9a-zA-Z]+|[0-9]+|[a-zA-Z]+)$";
                Regex messageRegex = new Regex(messagePattern);
                Match messageMatch = messageRegex.Match(input);

                string broadcastPattern = @"^([^0-9]+)( <-> )([a-zA-Z0-9]+|[a-zA-Z]+|[0-9]+)$";
                Regex broadcastRegex = new Regex(broadcastPattern);
                Match broadcastMatch = broadcastRegex.Match(input);

                if (!messageMatch.Success && !broadcastMatch.Success)
                {
                    input = Console.ReadLine();
                    continue;
                }
                else if (messageMatch.Success)
                {
                    string recipientCode = new string(messageMatch.Groups[1].Value.ToArray().Reverse().ToArray());
                    string message = messageMatch.Groups[3].Value;

                    if (!messagesDict.ContainsKey(recipientCode))
                        messagesDict.Add(recipientCode, new List<string>());

                    messagesDict[recipientCode].Add(message);
                }
                else if (broadcastMatch.Success)
                {
                    string message = broadcastMatch.Groups[1].Value;
                    char[] frequency = broadcastMatch.Groups[3].Value.ToArray();

                    for (int i = 0; i < frequency.Length; i++)
                    {
                        char current = frequency[i];

                        if ((int)current >= 97 && (int)current <= 122)
                            frequency[i] = char.Parse(frequency[i].ToString().ToUpper());
                        else if ((int)current >= 65 && (int)current <= 90)
                            frequency[i] = char.Parse(frequency[i].ToString().ToLower());
                    }

                    string decryptedFrequency = new string(frequency);

                    if (!broadcastsDict.ContainsKey(decryptedFrequency))
                        broadcastsDict.Add(decryptedFrequency, new List<string>());

                    broadcastsDict[decryptedFrequency].Add(message);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Broadcasts:");

            if (broadcastsDict.Count == 0)
                Console.WriteLine("None");
            else
            {
                foreach (var frequency in broadcastsDict)
                {
                    foreach (var message in frequency.Value)
                        Console.WriteLine($"{frequency.Key} -> {message}");
                }
            }

            Console.WriteLine("Messages:");

            if (messagesDict.Count == 0)
                Console.WriteLine("None");
            else
            {
                foreach (var recipient in messagesDict)
                {
                    foreach (var message in recipient.Value)
                        Console.WriteLine($"{recipient.Key} -> {message}");
                }
            }
        }
    }
}