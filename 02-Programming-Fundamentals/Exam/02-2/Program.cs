using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02
{
    // 50/100
    class Program
    {
        static void Main(string[] args)
        {
            int dnaLength = int.Parse(Console.ReadLine());

            // int = sample number KeyValuePair<length of longest squence, index of longest squence>
            var allSequencesDict = new Dictionary<int, KeyValuePair<int, int>>();
            var allSequencesList = new List<string>();
            var allSequencesBySumList = new List<int>();

            string input = Console.ReadLine();
            int count = 0;
            while (input != "Clone them!")
            {
                count++;
                string[] sequence = input.Split(new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries);

                string seqStr = string.Join("", sequence);
                int sumOfOnes = string.Join("", (seqStr.Split(new char[] { '0' }, StringSplitOptions.RemoveEmptyEntries))).Length;
                allSequencesList.Add(seqStr);
                allSequencesBySumList.Add(sumOfOnes);

                string pattern = @"1+";
                Regex regex = new Regex(pattern);

                List<string> allMatches = new List<string>();

                MatchCollection matches = regex.Matches(seqStr);

                string longestSeq = "";

                for (int i = 0; i < matches.Count; i++)
                {
                    string matchStr = matches[i].Value;

                    if (matchStr.Length > longestSeq.Length)
                    {
                        longestSeq = matchStr;
                    }
                }

                int length = longestSeq.Length;
                int index = seqStr.IndexOf(longestSeq);

                allSequencesDict.Add(count, new KeyValuePair<int, int>(length, index));

                input = Console.ReadLine();
            }

            var bestDna = allSequencesDict.OrderByDescending(x => x.Value.Key).ThenBy(x => x.Value.Value).First();
            
            Console.WriteLine($"Best DNA sample {bestDna.Key} with sum: {bestDna.Value.Key}.");
            char[] outputArr = allSequencesList[bestDna.Key - 1].ToCharArray();
            Console.WriteLine(string.Join(" ", outputArr));
        }
    }
}