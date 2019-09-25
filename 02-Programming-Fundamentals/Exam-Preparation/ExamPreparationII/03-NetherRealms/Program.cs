using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03_NetherRealms
{
    // 90/100
    class Program
    {
        static void Main(string[] args)
        {
            string[] deamons = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();

            var deamonsData = new SortedDictionary<string, KeyValuePair<int, double>>();

            foreach (var deamon in deamons)
            {
                string name = deamon;

                //calculate health
                Regex lettersRegex = new Regex(@"[^\+\-\.\/\*0-9]");
                MatchCollection letters = lettersRegex.Matches(deamon);
                int health = 0;
                foreach (Match letter in letters)
                {
                    char currentLetter = char.Parse(letter.Value);
                    health += (int)currentLetter;
                }

                //calculate damage
                Regex numsRegex = new Regex(@"[\+\-]*[\d.]+\d*");
                MatchCollection nums = numsRegex.Matches(deamon);
                double damage = 0.0;
                foreach (Match num in nums)
                {
                    damage += double.Parse(num.Value);
                }

                Regex operationsRegex = new Regex(@"[\*|\/]");
                MatchCollection operations = operationsRegex.Matches(deamon);
                foreach (Match operation in operations)
                {
                    if (operation.Value == "*")
                        damage *= 2;
                    else
                        damage /= 2;
                }

                deamonsData.Add(name, new KeyValuePair<int, double>(health, damage));               
            }

            foreach (var deamon in deamonsData)
            {
                Console.WriteLine($"{deamon.Key} - {deamon.Value.Key} health, {deamon.Value.Value:f2} damage");
            }
        }
    }
}