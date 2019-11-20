using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_HandsOfCards
{
    // 66/100
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, int>();

            for (int i = 0; ; i++)
            {
                string input = Console.ReadLine();

                if (input == "JOKER")
                    break;

                List<string> hands = input
                    .Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string name = hands[0];

                if (!dict.ContainsKey(name))
                    dict[name] = 0;

                List<string> cards = hands[1]
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Distinct()
                    .ToList();
               
                int totalSum = 0;

                foreach (var card in cards)
                {
                    string power = FindPower(card);
                    string type = FindType(card);
                    int powerValue = int.Parse(power);
                    int typeValue = int.Parse(type);
                    int sum = powerValue * typeValue;
                    totalSum += sum;
                }

                dict[name] += totalSum;
            }

            foreach (var p in dict)
            {
                Console.WriteLine($"{p.Key}: {p.Value}");
            }
        }

        static string FindPower(string card)
        {
            char[] arr = card.ToArray();
            string number = arr[0].ToString();
            char a = arr[0];

            switch (a)
            {
                case 'J':
                    number = "11";
                    break;
                case 'Q':
                    number = "12";
                    break;
                case 'K':
                    number = "13";
                    break;
                case 'A':
                    number = "14";
                    break;
            }

            return number;
        }

        static string FindType(string card)
        {
            char[] arr = card.ToArray();
            string number = arr[1].ToString();
            char a = arr[1];

            switch (a)
            {
                case 'S':
                    number = "4";
                    break;
                case 'H':
                    number = "3";
                    break;
                case 'D':
                    number = "2";
                    break;
                case 'C':
                    number = "1";
                    break;
            }

            return number;
        }
    }
}