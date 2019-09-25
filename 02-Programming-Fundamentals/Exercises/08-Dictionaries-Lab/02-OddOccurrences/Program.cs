using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().ToLower().Split().ToList();
            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (dict.ContainsKey(word))
                    dict[word]++;
                else
                    dict[word] = 1;
            }

            List<string> output = new List<string>();

            foreach (var item in dict)
            {
                if (item.Value % 2 == 1)
                {
                    output.Add(item.Key);
                }
            }

            Console.WriteLine(String.Join(", ", output));
        }
    }
}