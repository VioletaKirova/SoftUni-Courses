using System;
using System.Collections.Generic;
using System.Linq;

namespace _12_Google
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArgs = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string personName = inputArgs[0];

                if (!people.Any(p => p.Name == personName))
                {
                    Person newPerson = new Person(personName);
                    people.Add(newPerson);
                }

                Person currentPerson = people.Where(p => p.Name == personName).FirstOrDefault();

                string item = inputArgs[1];

                if (item == "company")
                {
                    string companyName = inputArgs[2];
                    string companyDepartment = inputArgs[3];
                    decimal companySalary = decimal.Parse(inputArgs[4]);

                    Company company = new Company(companyName, companyDepartment, companySalary);
                    currentPerson.Company = company;
                }
                else if (item == "pokemon")
                {
                    string pokemonName = inputArgs[2];
                    string pokemonType = inputArgs[3];

                    Pokemon pokemon = new Pokemon(pokemonName, pokemonType);
                    currentPerson.Pokemons.Add(pokemon);
                }
                else if (item == "parents")
                {
                    string parentName = inputArgs[2];
                    string parentBirthday = inputArgs[3];

                    Parent parent = new Parent(parentName, parentBirthday);
                    currentPerson.Parents.Add(parent);
                }
                else if (item == "children")
                {
                    string childName = inputArgs[2];
                    string childBirthday = inputArgs[3];

                    Child child = new Child(childName, childBirthday);
                    currentPerson.Children.Add(child);
                }
                else if (item == "car")
                {
                    string carModel = inputArgs[2];
                    string carSpeed = inputArgs[3];

                    Car car = new Car(carModel,carSpeed);
                    currentPerson.Car = car;
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            if (people.Any(p => p.Name == input))
            {
                Person personForOutput = people.Where(p => p.Name == input).FirstOrDefault();

                Console.WriteLine(personForOutput.Name);

                Console.WriteLine($"Company:");
                if (personForOutput.Company != null)
                {
                    Console.WriteLine($"{personForOutput.Company.Name} {personForOutput.Company.Department} {personForOutput.Company.Salary:f2}");
                }     
                
                Console.WriteLine($"Car:");
                if (personForOutput.Car != null)
                {
                    Console.WriteLine($"{personForOutput.Car.Model} {personForOutput.Car.Speed}");
                }
                
                Console.WriteLine($"Pokemon:");
                foreach (var pokemon in personForOutput.Pokemons)
                {
                    Console.WriteLine($"{pokemon.Name} {pokemon.Type}");
                }

                Console.WriteLine($"Parents:");
                foreach (var parent in personForOutput.Parents)
                {
                    Console.WriteLine($"{parent.Name} {parent.Birthday}");
                }

                Console.WriteLine($"Children:");
                foreach (var child in personForOutput.Children)
                {
                    Console.WriteLine($"{child.Name} {child.Birthday}");
                }
            }
        }
    }
}
