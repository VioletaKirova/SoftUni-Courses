using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_Wardrobe
{
    // 60/100

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new string[] {" ", "->", ","}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string color = input[0];

                if (!clothes.ContainsKey(color))
                {
                    clothes[color] = new Dictionary<string, int>();
                }

                for (int j = 1; j < input.Length; j++)
                {
                    string item = input[j];

                    if (!clothes[color].ContainsKey(item))
                    {
                        clothes[color][item] = 0;
                    }

                    clothes[color][item]++;
                }
            }

            string[] target = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string targetColour = target[0];
            string targetItem = target[1];

            foreach (var c in clothes)
            {
                Console.WriteLine($"{c.Key} clothes:");

                foreach (var clothingItem in c.Value)
                {
                    if (c.Key == targetColour && clothingItem.Key == targetItem)
                    {
                        Console.WriteLine($"* {clothingItem.Key} - {clothingItem.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothingItem.Key} - {clothingItem.Value}");
                    }
                }
            }
        }
    }
}
