using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02_ExtractSentencesByKeyword2
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();
            List<string> sentences = text.Split('.', '!', '?').ToList();

            for (int i = 0; i < sentences.Count; i++)
            {
                List<string> currentSen = sentences[i].Split(new char[] { ' ', ',', ';', '(', ')', '[', ']', '\\', '/', '\'', '\"' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                if (currentSen.Contains(word))
                {
                    Console.WriteLine(sentences[i].Trim());
                }
            }
        }
    }
}