using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03_WordCount
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, int> words = new Dictionary<string, int>();

            string wordsSourceFile = "..//..//..//..//Resources//words.txt";
            string textSourceFile = "..//..//..//..//Resources//text.txt";
            string destinationPath = "..//..//..//..//Resources//results.txt";

            using (StreamReader reader = new StreamReader(wordsSourceFile))
            {
                string word = reader.ReadLine();

                while (word != null)
                {
                    if (!words.ContainsKey(word))
                    {
                        words[word] = 0;
                    }

                    word = reader.ReadLine();
                }
            }

            using (StreamReader reader = new StreamReader(textSourceFile))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    line = line.ToLower();

                    string pattern = "[A-Za-z]+";
                    Regex regex = new Regex(pattern);
                    MatchCollection matches = regex.Matches(line);

                    foreach (Match match in matches)
                    {
                        if (words.ContainsKey(match.Value))
                        {
                            words[match.Value]++;
                        }
                    }

                    line = reader.ReadLine();
                }

                using (StreamWriter writer = new StreamWriter(destinationPath))
                {
                    foreach (var word in words.OrderByDescending(x => x.Value))
                    {
                        writer.WriteLine($"{word.Key} - {word.Value}");
                    }
                }
            }
        }
    }
}
