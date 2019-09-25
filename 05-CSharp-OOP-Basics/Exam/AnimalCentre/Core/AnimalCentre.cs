using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Hotels;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        private Hotel hotel;
        private Dictionary<string, List<string>> adoptedAnimals;
        private IProcedure chip;
        private IProcedure dentalCare;
        private IProcedure fitness;
        private IProcedure nailTrim;
        private IProcedure play;
        private IProcedure vaccinate;

        public AnimalCentre()
        {
            this.hotel = new Hotel();
            this.AdoptedAnimals = new Dictionary<string, List<string>>();;
            this.chip = new Chip();
            this.dentalCare = new DentalCare();
            this.fitness = new Fitness();
            this.nailTrim = new NailTrim();
            this.play = new Play();
            this.vaccinate = new Vaccinate();
        }

        public Dictionary<string, List<string>> AdoptedAnimals
        {
            get { return adoptedAnimals; }
            set { adoptedAnimals = value; }
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            IAnimal animal;

            switch (type)
            {
                case "Cat":
                    animal = new Cat(name, energy, happiness, procedureTime);
                    break;
                case "Dog":
                    animal = new Dog(name, energy, happiness, procedureTime);
                    break;
                case "Lion":
                    animal = new Lion(name, energy, happiness, procedureTime);
                    break;
                case "Pig":
                    animal = new Pig(name, energy, happiness, procedureTime);
                    break;
                default:
                    throw new NotImplementedException();
            }

            hotel.Accommodate(animal);

            return $"Animal {animal.Name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            CheckIfAnimalExists(name);

            IAnimal animal = this.hotel.Animals[name];

            //IProcedure procedure = new Chip();

            chip.DoService(animal, procedureTime);

            return $"{animal.Name} had chip procedure";
        }
        
        public string Vaccinate(string name, int procedureTime)
        {
            CheckIfAnimalExists(name);

            IAnimal animal = this.hotel.Animals[name];

            //IProcedure procedure = new Vaccinate();

            vaccinate.DoService(animal, procedureTime);

            return $"{animal.Name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            CheckIfAnimalExists(name);

            IAnimal animal = this.hotel.Animals[name];

            //IProcedure procedure = new Fitness();

            fitness.DoService(animal, procedureTime);

            return $"{animal.Name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            CheckIfAnimalExists(name);

            IAnimal animal = this.hotel.Animals[name];

            //IProcedure procedure = new Play();

            play.DoService(animal, procedureTime);

            return $"{animal.Name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            CheckIfAnimalExists(name);

            IAnimal animal = this.hotel.Animals[name];

            //IProcedure procedure = new DentalCare();

            dentalCare.DoService(animal, procedureTime);

            return $"{animal.Name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            CheckIfAnimalExists(name);

            IAnimal animal = this.hotel.Animals[name];

            //IProcedure procedure = new NailTrim();

            nailTrim.DoService(animal, procedureTime);

            return $"{animal.Name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            CheckIfAnimalExists(animalName);

            IAnimal animal = this.hotel.Animals[animalName];

            hotel.Adopt(animalName, owner);

            if (!this.AdoptedAnimals.ContainsKey(owner))
            {
                this.AdoptedAnimals[owner] = new List<string>();
            }

            this.AdoptedAnimals[owner].Add(animal.Name);

            if (animal.IsChipped)
            {
                return $"{owner} adopted animal with chip";
            }
            else
            {
                return $"{owner} adopted animal without chip";
            }
        }

        public string History(string type)
        {
            IProcedure procedure;

            switch (type)
            {
                case "Chip":
                    procedure = this.chip;
                    break;
                case "DentalCare":
                    procedure = this.dentalCare;
                    break;
                case "Fitness":
                    procedure = this.fitness;
                    break;
                case "NailTrim":
                    procedure = this.nailTrim;
                    break;
                case "Play":
                    procedure = this.play;
                    break;
                case "Vaccinate":
                    procedure = this.vaccinate;
                    break;
                default:
                    throw new NotImplementedException();
            }

            return procedure.History();
        }

        private void CheckIfAnimalExists(string name)
        {
            if (!hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
        }
    }
}
