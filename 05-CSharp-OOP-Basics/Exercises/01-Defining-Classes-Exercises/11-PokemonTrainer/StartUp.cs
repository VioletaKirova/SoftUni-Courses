using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string input = Console.ReadLine();

            while (input != "Tournament")
            {
                string[] inputArgs = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string trainerName = inputArgs[0];
                string pokemonName = inputArgs[1];
                string pokemonElement = inputArgs[2];
                int pokemonHealth = int.Parse(inputArgs[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.Any(x => x.Name == trainerName))
                {
                    Trainer newTrainer = new Trainer(trainerName);
                    trainers.Add(newTrainer);
                }

                Trainer currentTrainer = trainers.Where(x => x.Name == trainerName).FirstOrDefault();

                currentTrainer.Pokemons.Add(pokemon);
             
                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {
                if (input != "Tournament")
                {
                    foreach (var trainer in trainers)
                    {
                        if (trainer.Pokemons.Any(x => x.Element == input))
                        {
                            trainer.Badges++;
                        }
                        else
                        {
                            foreach (var pokemon in trainer.Pokemons)
                            {
                                pokemon.Health -= 10;
                            }
                        }
                    }

                    foreach (var trainer in trainers)
                    {
                        trainer.Pokemons.RemoveAll(x => x.Health <= 0);
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}
