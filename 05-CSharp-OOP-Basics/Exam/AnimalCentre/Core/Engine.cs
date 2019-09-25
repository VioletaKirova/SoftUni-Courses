using System;
using System.Linq;

namespace AnimalCentre.Core
{
    public class Engine
    {
        private AnimalCentre animalCentre;

        public Engine()
        {
            animalCentre = new AnimalCentre();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string commandType = commandArgs[0];

                string result = string.Empty;

                string name;
                int procedureTime;

                try
                {
                    switch (commandType)
                    {
                        case "RegisterAnimal":
                            string type = commandArgs[1];
                            name = commandArgs[2];
                            int energy = int.Parse(commandArgs[3]);
                            int happiness = int.Parse(commandArgs[4]);
                            procedureTime = int.Parse(commandArgs[5]);
                            result = animalCentre.RegisterAnimal(type, name, energy, happiness, procedureTime);
                            break;
                        case "Chip":
                            name = commandArgs[1];
                            procedureTime = int.Parse(commandArgs[2]);
                            result = animalCentre.Chip(name, procedureTime);
                            break;
                        case "Vaccinate":
                            name = commandArgs[1];
                            procedureTime = int.Parse(commandArgs[2]);
                            result = animalCentre.Vaccinate(name, procedureTime);
                            break;
                        case "Fitness":
                            name = commandArgs[1];
                            procedureTime = int.Parse(commandArgs[2]);
                            result = animalCentre.Fitness(name, procedureTime);
                            break;
                        case "Play":
                            name = commandArgs[1];
                            procedureTime = int.Parse(commandArgs[2]);
                            result = animalCentre.Play(name, procedureTime);
                            break;
                        case "DentalCare":
                            name = commandArgs[1];
                            procedureTime = int.Parse(commandArgs[2]);
                            result = animalCentre.DentalCare(name, procedureTime);
                            break;
                        case "NailTrim":
                            name = commandArgs[1];
                            procedureTime = int.Parse(commandArgs[2]);
                            result = animalCentre.NailTrim(name, procedureTime);
                            break;
                        case "Adopt":
                            string animalName = commandArgs[1];
                            string owner = commandArgs[2];
                            result = animalCentre.Adopt(animalName, owner);
                            break;
                        case "History":
                            string procedureType = commandArgs[1];
                            result = animalCentre.History(procedureType);
                            break;
                    }

                    Console.WriteLine(result);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("InvalidOperationException: " + ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("ArgumentException: " + ex.Message);
                }

                command = Console.ReadLine();
            }

            foreach (var owner in this.animalCentre.AdoptedAnimals.OrderBy(x => x.Key))
            {
                Console.WriteLine($"--Owner: {owner.Key}");
                Console.WriteLine($"    - Adopted animals: {string.Join(' ', owner.Value)}");
            }
        }
    }
}
