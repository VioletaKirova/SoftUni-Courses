using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, SortedDictionary<string, List<int>>>();

            //default values
            int defDamage = 45;
            int defHealth = 250;
            int defArmor = 10;

            for (int i = 0; i < n; i++)
            {
                List<string> input = Console.ReadLine().Split(' ').ToList();
                //example: Red Bazgargal 100 2500 25
                //example: Gold Traxx 500 null 0

                string type = input[0];
                string name = input[1];

                bool checkDamage = false;
                bool checkHealth = false;
                bool checkArmor = false;

                int damage = -1;
                if (input[2] == "null")
                    damage = defDamage;
                else
                    checkDamage = int.TryParse(input[2], out damage);

                int health = -1;
                if (input[3] == "null")
                    health = defHealth;
                else
                    checkHealth = int.TryParse(input[3], out health);

                int armor = -1;
                if (input[4] == "null")
                    armor = defArmor;
                else   
                    checkArmor = int.TryParse(input[4], out armor);

                List<int> stats = new List<int>();

                stats.Add(damage);
                stats.Add(health);
                stats.Add(armor);

                if (!dict.ContainsKey(type))
                {
                    dict[type] = new SortedDictionary<string, List<int>>();
                }

                dict[type][name] = stats;
            }

            foreach (var type in dict)
            {
                double sumDamage = 0.0;
                double sumHealth = 0.0;
                double sumArmor = 0.0;

                foreach (var dragon in type.Value)
                {
                    sumDamage += dragon.Value[0];
                    sumHealth += dragon.Value[1];
                    sumArmor += dragon.Value[2];                  
                }

                double averageDamage = sumDamage / type.Value.Count;
                double averageHealth = sumHealth / type.Value.Count;
                double averageArmor = sumArmor / type.Value.Count;

                Console.WriteLine($"{type.Key}::({averageDamage:f2}/{averageHealth:f2}/{averageArmor:f2})");

                foreach (var dragon in type.Value)
                {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value[0]}, health: {dragon.Value[1]}, armor: {dragon.Value[2]}");
                }
            }
        }
    }
}