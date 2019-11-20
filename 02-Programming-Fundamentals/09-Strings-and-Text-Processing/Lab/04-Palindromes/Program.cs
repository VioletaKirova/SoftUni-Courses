using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new char[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> output = new List<string>();

            foreach (var word in input)
            {
                char[] firstHalf = word.Take(word.Length / 2).ToArray();
                char[] secondHalf = new char[firstHalf.Length];

                if (word.Length % 2 == 1)
                    secondHalf = word.Skip(word.Length / 2 + 1).Reverse().ToArray();
                else
                    secondHalf = word.Skip(word.Length / 2).Reverse().ToArray();

                string firstHalfStr = string.Join("", firstHalf);
                string secondHalfStr = string.Join("", secondHalf);

                if (firstHalfStr.Equals(secondHalfStr))
                {
                    string palindrome = word;
                    output.Add(palindrome);
                }
            }

            Console.WriteLine(string.Join(", ", output.Distinct().OrderBy(a => a)));
        }
    }
}