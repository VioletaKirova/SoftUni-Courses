using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_PopulationCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, Dictionary<string, long>>();
            string input = Console.ReadLine();
            //example: Sofia|Bulgaria|1000000

            while (input != "report")
            {
                List<string> parsedInput = input
                    .Split('|')
                    .ToList();

                string city = parsedInput[0];
                string country = parsedInput[1];
                long cityPopulaton = long.Parse(parsedInput[2]);

                if (!dict.ContainsKey(country))
                {
                    dict[country] = new Dictionary<string, long>();
                }

                dict[country][city] = cityPopulaton;

                input = Console.ReadLine();
            }

            var sorted = dict
                .OrderByDescending(n => n.Value.Values.Sum())
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var country in sorted)
            {
                Console.WriteLine($"{country.Key} (total population: {country.Value.Values.Sum()})");

                foreach (var city in country.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}