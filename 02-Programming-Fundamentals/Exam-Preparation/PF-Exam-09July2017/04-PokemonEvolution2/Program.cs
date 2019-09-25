using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_PokemonEvolution
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var allPokemons = new Dictionary<string, List<KeyValuePair<string, int>>>();

            while (input != "wubbalubbadubdub")
            {
                if (input.Contains(" -> "))
                {
                    string[] inputArr = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string name = inputArr[0];
                    string type = inputArr[1];
                    int index = int.Parse(inputArr[2]);

                    if (!allPokemons.ContainsKey(name))
                        allPokemons.Add(name, new List <KeyValuePair<string, int>>());

                    allPokemons[name].Add(new KeyValuePair<string, int>(type, index));
                }
                else
                {
                    string name = input;

                    if (allPokemons.ContainsKey(name))
                    {
                        Console.WriteLine($"# {name}");

                        for (int i = 0; i < allPokemons[name].Count; i++)
                        {
                            Console.WriteLine($"{allPokemons[name][i].Key} <-> {allPokemons[name][i].Value}");
                        }
                    }                   
                }

                input = Console.ReadLine();
            }

            foreach (var pokemon in allPokemons)
            {
                Console.WriteLine($"# {pokemon.Key}");

                foreach (var type in pokemon.Value.OrderBy(x => -x.Value))
                {
                    Console.WriteLine($"{type.Key} <-> {type.Value}");
                }
            }
        }
    }
}