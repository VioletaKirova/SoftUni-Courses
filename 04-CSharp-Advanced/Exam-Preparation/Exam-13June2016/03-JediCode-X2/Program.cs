using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.JediCodeX
{
    public class JediCodeX
    {
        public static void Main()
        {
            var count = int.Parse(Console.ReadLine());
            StringBuilder inputLines = new StringBuilder();
            for (var i = 0; i < count; i++)
            {
                inputLines.Append(Console.ReadLine().Trim());
            }
            var patternName = Console.ReadLine();
            var patternMessage = Console.ReadLine();
            var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var jedis = new List<string>();
            var messages = new List<string>();

            var matchedNames = Regex.Matches(
                    inputLines.ToString(),
                    patternName + @"([a-zA-Z]{" + patternName.Length + @"})(?![a-zA-Z])");
            foreach (Match match in matchedNames)
            {
                jedis.Add(match.Groups[1].Value);
            }

            var matchedMessages = Regex.Matches(
                inputLines.ToString(),
                patternMessage + @"([a-zA-Z0-9]{" + patternMessage.Length + @"})(?![a-zA-Z0-9])");
            foreach (Match match in matchedMessages)
            {
                messages.Add(match.Groups[1].Value);
            }
            var curentJedi = 0;
            var result = new List<string>();
            for (int i = 0; i < indexes.Length; i++)
            {
                if (indexes[i] - 1 < messages.Count)
                {
                    result.Add($"{jedis[curentJedi++]} - {messages[indexes[i] - 1]}");
                }
                if (curentJedi >= jedis.Count) break;
            }

            Console.WriteLine(string.Join("\n", result));
        }
    }
}