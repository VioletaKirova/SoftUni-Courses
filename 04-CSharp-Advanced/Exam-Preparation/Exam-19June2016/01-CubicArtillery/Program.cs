using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_CubicArtillery
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, List<int>> bunkerValues = new Dictionary<char, List<int>>();
            Queue<char> bunkers = new Queue<char>();

            int capacity = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "Bunker Revision")
            {
                string[] inputArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                foreach (var arg in inputArgs)
                {
                    if (!char.IsDigit(arg[0]))
                    {
                        bunkers.Enqueue(arg[0]);
                        bunkerValues[arg[0]] = new List<int>();
                    }
                    else
                    {                       
                        int weaponSize = int.Parse(arg);

                        char currentBunker = bunkers.Peek();
                        int currentBunkerValue = bunkerValues[currentBunker].Sum();

                        if (currentBunkerValue + weaponSize <= capacity)
                        {
                            bunkerValues[currentBunker].Add(weaponSize);
                        }
                        else if (bunkers.Count == 1 && weaponSize < capacity)
                        {
                            while (bunkerValues[bunkers.Peek()].Sum() + weaponSize > capacity)
                            {
                                bunkerValues[bunkers.Peek()].RemoveAt(0);
                            }

                            bunkerValues[bunkers.Peek()].Add(weaponSize);
                        }
                        else
                        {
                            foreach (var bunker in bunkerValues)
                            {
                                if (bunker.Value.Sum() + weaponSize < capacity)
                                {
                                    bunkerValues[bunker.Key].Add(weaponSize);
                                    break;
                                }
                            }
                        }

                        if (bunkerValues[bunkers.Peek()].Sum() == capacity && bunkers.Count > 1)
                        {
                            char bunkerToDequeue = bunkers.Dequeue();

                            Console.WriteLine($"{bunkerToDequeue} -> {string.Join(", ", bunkerValues[bunkerToDequeue])}");

                            bunkerValues.Remove(bunkerToDequeue);
                        }
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
