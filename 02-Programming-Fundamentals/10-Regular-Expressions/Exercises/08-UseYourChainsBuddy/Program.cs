using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _08_UseYourChainsBuddy
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            //Extract text from <p> tags:
            string pattern1 = @"(<p>)(.+?)(<\/p>)";
            MatchCollection matches = Regex.Matches(input, pattern1);
            string allMatches = "";

            foreach (Match m in matches)
            {
                allMatches += m.Groups[2].Value;
            }

            //Replace all chars that are not small letters or numbers:
            string pattern2 = @"[^a-z0-9]";
            Regex regex2 = new Regex(pattern2);
            string text = regex2.Replace(allMatches, " ");

            //Replace all multispaces with a single space:
            string pattern3 = @"\s+";
            Regex regex3 = new Regex(pattern3);
            string redusedSpacesText = regex3.Replace(text, " ");
            StringBuilder decryptedText = new StringBuilder(redusedSpacesText);

            for (int i = 0; i < decryptedText.Length; i++)
            {
                switch (decryptedText[i])
                {
                    case 'a': decryptedText[i] = 'n'; break;
                    case 'b': decryptedText[i] = 'o'; break;
                    case 'c': decryptedText[i] = 'p'; break;
                    case 'd': decryptedText[i] = 'q'; break;
                    case 'e': decryptedText[i] = 'r'; break;
                    case 'f': decryptedText[i] = 's'; break;
                    case 'g': decryptedText[i] = 't'; break;
                    case 'h': decryptedText[i] = 'u'; break;
                    case 'i': decryptedText[i] = 'v'; break;
                    case 'j': decryptedText[i] = 'w'; break;
                    case 'k': decryptedText[i] = 'x'; break;
                    case 'l': decryptedText[i] = 'y'; break;
                    case 'm': decryptedText[i] = 'z'; break;
                    case 'n': decryptedText[i] = 'a'; break;
                    case 'o': decryptedText[i] = 'b'; break;
                    case 'p': decryptedText[i] = 'c'; break;
                    case 'q': decryptedText[i] = 'd'; break;
                    case 'r': decryptedText[i] = 'e'; break;
                    case 's': decryptedText[i] = 'f'; break;
                    case 't': decryptedText[i] = 'g'; break;
                    case 'u': decryptedText[i] = 'h'; break;
                    case 'v': decryptedText[i] = 'i'; break;
                    case 'w': decryptedText[i] = 'j'; break;
                    case 'x': decryptedText[i] = 'k'; break;
                    case 'y': decryptedText[i] = 'l'; break;
                    case 'z': decryptedText[i] = 'm'; break;                    
                }
            }

            Console.WriteLine(decryptedText.ToString());
        }
    }
}