using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_HornetArmada
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = string.Empty;

            var legionActivity = new Dictionary<string, int>();
            var soldierTypeByLegion = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                string[] soldierData = input.Split(new char[] { ' ', '=', '-', '>', ':' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                int lastActivity = int.Parse(soldierData[0]);
                string legionName = soldierData[1];
                string soldierType = soldierData[2];
                int soldierCount = int.Parse(soldierData[3]);

                if (!legionActivity.ContainsKey(legionName))
                    legionActivity.Add(legionName, lastActivity);
                else if (legionActivity[legionName] < lastActivity)
                    legionActivity[legionName] = lastActivity;

                if (!soldierTypeByLegion.ContainsKey(legionName))
                    soldierTypeByLegion.Add(legionName, new Dictionary<string, int>());

                if (!soldierTypeByLegion[legionName].ContainsKey(soldierType))
                    soldierTypeByLegion[legionName].Add(soldierType, soldierCount);
                else if (soldierTypeByLegion[legionName][soldierType] < soldierCount)
                    soldierTypeByLegion[legionName][soldierType] += soldierCount;
            }

            string command = Console.ReadLine();

            if (command.Contains('\\'))
            {
                string[] commandData = command.Split('\\');
                int activityData = int.Parse(commandData[0]);
                string soldierTypeData = commandData[1];

                List<string> legionsWithLowerActivity = new List<string>();

                foreach (var legion in legionActivity)
                {
                    if (legion.Value < activityData)
                        legionsWithLowerActivity.Add(legion.Key);
                }

                foreach (var legion in soldierTypeByLegion.OrderByDescending(x => x.Value.Values.Sum()))
                {
                    if (legionsWithLowerActivity.Contains(legion.Key))
                    {
                        if (legion.Value.ContainsKey(soldierTypeData))
                            Console.WriteLine($"{legion.Key} -> {legion.Value[soldierTypeData]}");
                    }                  
                }
            }
            else
            {
                string type = command;
                List<string> neededLegions = new List<string>();

                foreach (var legion in soldierTypeByLegion.Where(x => x.Value.ContainsKey(type)))
                    neededLegions.Add(legion.Key);

                foreach (var legion in legionActivity.OrderByDescending(x => x.Value))
                {
                    if (neededLegions.Contains(legion.Key))
                        Console.WriteLine($"{legion.Value} : {legion.Key}");
                }
            }
        }
    }
}