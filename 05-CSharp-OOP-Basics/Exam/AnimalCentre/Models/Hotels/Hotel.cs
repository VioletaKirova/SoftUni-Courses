using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;

namespace AnimalCentre.Models.Hotels
{
    public class Hotel : IHotel
    {
        private const int defaultCapacity = 10;

        private int capacity;
        private Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            this.Capacity = defaultCapacity;
            this.animals = new Dictionary<string, IAnimal>();
        }

        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }

        public IReadOnlyDictionary<string, IAnimal> Animals => (IReadOnlyDictionary<string, IAnimal>)animals;

        public void Accommodate(IAnimal animal)
        {
            if (this.Capacity == this.Animals.Count)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (this.Animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }

            this.animals.Add(animal.Name, animal);
        }

        public void Adopt(string animalName, string owner)
        {
            if (!this.Animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            this.Animals[animalName].Owner = owner;
            this.Animals[animalName].IsAdopt = true;

            this.animals.Remove(animalName);
        }
    }
}
