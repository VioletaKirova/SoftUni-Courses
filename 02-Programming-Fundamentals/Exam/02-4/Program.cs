using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02
{
    // 100/100
    class Program
    {
        class Sequence
        {
            public string SeqStr { get; set; }
            public int SampleNumber { get; set; }
            public int IndexOfLongestSeq { get; set; }
            public int LengthOtLongestSeq { get; set; }
            public int SumOfOnes { get; set; }
        }
        static void Main(string[] args)
        {
            int dnaLength = int.Parse(Console.ReadLine());

            // int = sample number KeyValuePair<length of longest squence, index of longest squence>

            var allSequencesList = new List<Sequence>();

            string input = Console.ReadLine();
            int count = 0;

            while (input != "Clone them!")
            {
                count++;
                string[] sequence = input.Split(new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries);

                string seqStr = string.Join("", sequence);
                int sumOfOnes = string.Join("", (seqStr.Split(new char[] { '0' }, StringSplitOptions.RemoveEmptyEntries))).Length;

                string pattern = @"1+";
                Regex regex = new Regex(pattern);
                MatchCollection matches = regex.Matches(seqStr);

                List<string> allMatches = new List<string>();

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

                Sequence newSeq = new Sequence();
                newSeq.SeqStr = seqStr;
                newSeq.SampleNumber = count;
                newSeq.LengthOtLongestSeq = length;
                newSeq.IndexOfLongestSeq = index;
                newSeq.SumOfOnes = sumOfOnes;

                allSequencesList.Add(newSeq);

                input = Console.ReadLine();
            }

            var bestDna = allSequencesList.OrderByDescending(x => x.LengthOtLongestSeq).ThenBy(x => x.IndexOfLongestSeq).ThenBy(x => x.SumOfOnes).First();

            var besrDnaIndex = bestDna.IndexOfLongestSeq;
            var bestDnaLen = bestDna.LengthOtLongestSeq;

            var seqsWithSameIndexAndLen = allSequencesList.Where(x => x.IndexOfLongestSeq == besrDnaIndex && x.LengthOtLongestSeq == bestDnaLen);
            var bestDnaBySum = seqsWithSameIndexAndLen.OrderByDescending(x => x.SumOfOnes).First();

            if (seqsWithSameIndexAndLen.Count() > 1)
            {
                Console.WriteLine($"Best DNA sample {bestDnaBySum.SampleNumber} with sum: {bestDnaBySum.SumOfOnes}.");
                char[] outputArr = bestDnaBySum.SeqStr.ToCharArray();
                Console.WriteLine(string.Join(" ", outputArr));
            }
            else
            {
                Console.WriteLine($"Best DNA sample {bestDna.SampleNumber} with sum: {bestDna.SumOfOnes}.");
                char[] outputArr = bestDna.SeqStr.ToCharArray();
                Console.WriteLine(string.Join(" ", outputArr));
            }           
        }
    }
}