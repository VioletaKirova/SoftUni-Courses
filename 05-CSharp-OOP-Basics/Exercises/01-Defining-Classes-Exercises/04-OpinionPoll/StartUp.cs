using System;
using System.Collections.Generic;

namespace _04_OpinionPoll
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Group group = new Group();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);

                group.AddPerson(person);
            }

            List<Person> filteredPeople = group.FilterGroup();

            foreach (var person in filteredPeople)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
