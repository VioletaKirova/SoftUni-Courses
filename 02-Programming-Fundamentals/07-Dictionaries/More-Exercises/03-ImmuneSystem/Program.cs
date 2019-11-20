using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_ImmuneSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialHealth = int.Parse(Console.ReadLine());
            var viruses = new Dictionary<string, int>();
            string input = Console.ReadLine();
            int finalHealth = initialHealth;
            bool defeated = false;

            while (input != "end")
            {
                char[] inputArr = input.ToArray();
                int sum = 0;

                foreach (var ch in inputArr)
                    sum += (int)ch;

                int virusStrength = sum / 3;
                int defeatTimeSecs = 0;
                string defeatTime = "";

                if (!viruses.ContainsKey(input))
                {
                    defeatTimeSecs = (int)virusStrength * inputArr.Length;
                    defeatTime = $"{defeatTimeSecs / 60}m {defeatTimeSecs % 60}s";

                    viruses[input] = virusStrength;
                }
                else
                {
                    defeatTimeSecs = (int)virusStrength * inputArr.Length / 3;
                    defeatTime = $"{defeatTimeSecs / 60}m {defeatTimeSecs % 60}s";

                    viruses[input] = virusStrength;
                }                

                if (finalHealth >= defeatTimeSecs)
                {
                    finalHealth -= defeatTimeSecs;
                }
                else
                {
                    defeated = true;
                    Console.WriteLine($"Virus {input}: {virusStrength} => {defeatTimeSecs} seconds");
                    Console.WriteLine("Immune System Defeated.");
                    break;
                }

                Console.WriteLine($"Virus {input}: {virusStrength} => {defeatTimeSecs} seconds");
                Console.WriteLine($"{input} defeated in {defeatTime}.");
                Console.WriteLine($"Remaining health: {finalHealth}");

                finalHealth += finalHealth * 20 / 100;

                if (finalHealth > initialHealth)
                    finalHealth = initialHealth;

                input = Console.ReadLine();
            }

            if (!defeated)
                Console.WriteLine($"Final Health: {finalHealth}");
        }
    }
}