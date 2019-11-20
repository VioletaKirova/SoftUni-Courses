using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08_LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            double result = 0.0;

            for (int i = 0; i < input.Length; i++)
            {
                string currentLine = input[i];
                char firstLetter = currentLine[0];
                char secondLetter = currentLine[currentLine.Length - 1];
                int lengthOfNumber = currentLine.Length - 2;
                int number = int.Parse(string.Join("", currentLine.Skip(1).Take(lengthOfNumber)));
                double currentResult = number;
                int position = 0;

                if (firstLetter >= 'A' && firstLetter <= 'Z')
                {
                    position = (int)firstLetter - 64;
                    currentResult /= position;
                }
                else if (firstLetter >= 'a' && firstLetter <= 'z')
                {
                    position = (int)firstLetter - 96;
                    currentResult *= position;
                }

                if (secondLetter >= 'A' && secondLetter <= 'Z')
                {
                    position = (int)secondLetter - 64;
                    currentResult -= position;
                }
                else if (secondLetter >= 'a' && secondLetter <= 'z')
                {
                    position = (int)secondLetter - 96;
                    currentResult += position;
                }

                result += currentResult;
            }

            Console.WriteLine($"{result:f2}");
        }
    }
}