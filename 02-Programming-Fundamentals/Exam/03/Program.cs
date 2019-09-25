using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03
{
    class Planet
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public string AttackType { get; set; }
        public int SoldierCount { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Planet> allPlanets = new List<Planet>();
            List<Planet> attackedPlanets = new List<Planet>();
            List<Planet> destroyedPlanets = new List<Planet>();

            for (int i = 0; i < n; i++)
            {
                string encryptedMessage = Console.ReadLine();

                int count = 0;

                foreach (var symbol in encryptedMessage.ToUpper())
                {
                    if (symbol == 'S'|| symbol == 'T' || symbol == 'A' || symbol == 'R')
                    {
                        count++;
                    }
                }

                char[] encryptedArr = encryptedMessage.ToCharArray();

                for (int j = 0; j < encryptedArr.Length; j++)
                {
                    encryptedArr[j] = (char)((int)encryptedArr[j] - count);
                }

                string decryptedMessage = string.Join("", encryptedArr);

                string fullPattern = @"^[^@\-\!:>]*@([a-zA-Z]+)[^@\-\!:>]*:([\d]+)[^@\-\!:>]*!([A|D])![^@\-\!:>]*\->([\d]+)[^@\-\!:>]*$";
                Regex fullMessageRegex = new Regex(fullPattern);
                Match matchFullMessage = fullMessageRegex.Match(decryptedMessage);

                if (!matchFullMessage.Success)
                {
                    continue;
                }

                string namePattern = @"@([a-zA-Z]+)";
                string populationPattern = @":([\d]+)";
                string attackTypePattern = @"!([A|D])!";
                string soldierCountPattern = @"\->([\d]+)";

                Regex nameRegex = new Regex(namePattern);
                Regex populationRegex = new Regex(populationPattern);
                Regex attackTypeRegex = new Regex(attackTypePattern);
                Regex soldierCountRegex = new Regex(soldierCountPattern);

                Match matchName = nameRegex.Match(decryptedMessage);
                Match matchPopulation = populationRegex.Match(decryptedMessage);
                Match matchAttachType = attackTypeRegex.Match(decryptedMessage);
                Match matchSoldierCount = soldierCountRegex.Match(decryptedMessage);

                if (matchName.Success && matchPopulation.Success && matchAttachType.Success && matchSoldierCount.Success)
                {
                    Planet newPlanet = new Planet();
                    newPlanet.Name = matchName.Groups[1].Value;
                    newPlanet.Population = int.Parse(matchPopulation.Groups[1].Value);
                    newPlanet.AttackType = matchAttachType.Groups[1].Value;
                    newPlanet.SoldierCount = int.Parse(matchPopulation.Groups[1].Value);

                    allPlanets.Add(newPlanet);
                }
            }

            foreach (var planet in allPlanets)
            {
                if (planet.AttackType == "A")
                {
                    attackedPlanets.Add(planet);
                }
                else
                {
                    destroyedPlanets.Add(planet);
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");

            foreach (var planet in attackedPlanets.OrderBy(x => x.Name))
            {
                Console.WriteLine($"-> {planet.Name}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

            foreach (var planet in destroyedPlanets.OrderBy(x => x.Name))
            {
                Console.WriteLine($"-> {planet.Name}");
            }
        }
    }
}