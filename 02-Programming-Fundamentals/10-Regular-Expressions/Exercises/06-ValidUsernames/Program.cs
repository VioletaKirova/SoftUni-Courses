using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _06_ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(new char[] { ' ', '\\', '/', '(', ')' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string regex = @"^[A-Za-z]([A-Za-z0-9_]{2,24})$";
            List<string> matchedNames = new List<string>();

            foreach (var name in names)
            {
                Match match = Regex.Match(name, regex);

                if (match.Success)
                {
                    matchedNames.Add(match.Value);
                }
            }

            int biggestSum = 0;
            string firstName = "";
            string secondName = "";

            for (int i = 0; i < matchedNames.Count; i++)
            {
                if (i != matchedNames.Count - 1)
                {
                    int currentSum = matchedNames[i].Length + matchedNames[i + 1].Length;

                    if (currentSum > biggestSum)
                    {
                        biggestSum = currentSum;
                        firstName = matchedNames[i];
                        secondName = matchedNames[i + 1];
                    }
                }            
            }

            Console.WriteLine(firstName);
            Console.WriteLine(secondName);
        }
    }
}