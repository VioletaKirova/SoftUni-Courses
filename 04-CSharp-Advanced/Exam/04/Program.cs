using System;
using System.Collections.Generic;
using System.Linq;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cups = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] bottles = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int wastedWater = 0;

            Queue<int> cupsCapacity = new Queue<int>(cups);
            Stack<int> bottlesCapacity = new Stack<int>(bottles);

            bool noMoreCups = false;
            bool noMoreBottles = false;

            while (cupsCapacity.Any() && bottlesCapacity.Any())
            {
                int currentCup = cupsCapacity.Peek();

                while (currentCup > 0)
                {
                    if (bottlesCapacity.Any())
                    {
                        int currentBottle = bottlesCapacity.Pop();

                        currentCup -= currentBottle;

                        if (currentCup <= 0)
                        {
                            cupsCapacity.Dequeue();

                            wastedWater += Math.Abs(currentCup);
                        }

                        if (bottlesCapacity.Count == 0)
                        {
                            break;
                        }
                    }                   
                }

                if (!cupsCapacity.Any())
                {
                    noMoreCups = true;
                }
                else if (!bottlesCapacity.Any())
                {
                    noMoreBottles = true;
                }
            }

            if (noMoreCups)
            {
                Console.WriteLine($"Bottles: {string.Join(' ', bottlesCapacity)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            else if (noMoreBottles)
            {
                Console.WriteLine($"Cups: {string.Join(' ', cupsCapacity)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
        }
    }
}
