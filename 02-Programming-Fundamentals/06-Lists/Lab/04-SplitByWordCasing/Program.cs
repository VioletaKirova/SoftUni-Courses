using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_SplitByWordCasing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console
                .ReadLine()
                .Split(',', ';', ':', '.', '!', '(', ')', '"', '\'', '\\', '/', '[', ']', ' ')
                .ToList();

            List<string> lowerCaseWords = new List<string>();
            List<string> upperCaseWords = new List<string>();
            List<string> mixedCaseWords = new List<string>();

            bool lowerCase = false;
            bool upperCase = false;
            bool other = false;

            foreach (var word in words)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] >= (char)97 && word[i] <= (char)122)
                    {
                        lowerCase = true;
                    }
                    else if (word[i] >= (char)65 && word[i] <= (char)90)
                    {
                        upperCase = true;
                    }
                    else
                    {
                        other = true;
                    }

                    if (i == word.Length - 1)
                    {
                        if (lowerCase && !upperCase && !other)
                        {
                            lowerCaseWords.Add(word);
                        }
                        else if (upperCase && !lowerCase && !other)
                        {
                            upperCaseWords.Add(word);
                        }
                        else
                        {
                            mixedCaseWords.Add(word);
                        }

                        lowerCase = false;
                        upperCase = false;
                        other = false;
                    }
                }
            }

            Console.WriteLine($"Lower-case: {string.Join(", ", lowerCaseWords)}");
            Console.WriteLine($"Mixed-case: {string.Join(", ", mixedCaseWords)}");
            Console.WriteLine($"Upper-case: {string.Join(", ", upperCaseWords)}");
        }
    }
}