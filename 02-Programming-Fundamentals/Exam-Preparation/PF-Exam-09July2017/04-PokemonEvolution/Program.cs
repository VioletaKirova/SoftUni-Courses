using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_PokemonEvolution
{
    // 10/100
    class Program
    {   
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var allPokemons = new Dictionary<string, Dictionary<string, List<int>>>();

            while (input != "wubbalubbadubdub")
            {
                if (input.Contains(" -> "))
                {
                    string[] inputArr = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string name = inputArr[0];
                    string type = inputArr[1];
                    int index = int.Parse(inputArr[2]);

                    if (!allPokemons.ContainsKey(name))
                        allPokemons.Add(name, new Dictionary<string, List<int>>());

                    if (!allPokemons[name].ContainsKey(type))
                        allPokemons[name].Add(type, new List<int>());

                    allPokemons[name][type].Add(index);
                }
                else
                {
                    string name = input;

                    Console.WriteLine($"# {name}");

                    foreach (var type in allPokemons[name])
                    {
                        for (int i = 0; i < type.Value.Count; i++)
                        {
                            Console.WriteLine($"{type.Key} <-> {type.Value[i]}");
                        }
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var pokemon in allPokemons)
            {
                Console.WriteLine($"# {pokemon.Key}");

                foreach (var pokemonValue in allPokemons[pokemon.Key])
                {
                    for (int i = 0; i < pokemonValue.Value.Count; i++)
                    {
                        Console.WriteLine($"{pokemonValue.Key} <-> {pokemonValue.Value[i]}");
                    }
                }
            }
        }
    }
}