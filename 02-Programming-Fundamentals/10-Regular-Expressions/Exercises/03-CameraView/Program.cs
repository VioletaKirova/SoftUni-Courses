using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03_CameraView
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int elementsToSkip = nums[0];
            int elementsToTake = nums[1];
            string text = Console.ReadLine();
            string camera = $@"\|<[\w]*";
            MatchCollection matches = Regex.Matches(text, camera);
            string[] matchesCast = matches.Cast<Match>().Select(m => m.Value).ToArray();
            List<string> output = new List<string>();

            foreach (var match in matchesCast)
            {
                string taken = new string(match.Skip(elementsToSkip + 2).Take(elementsToTake).ToArray());
                output.Add(taken);
            }

            Console.WriteLine(string.Join(", ", output));
        }
    }
}