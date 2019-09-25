namespace _06_StrategyPattern
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            SortedSet<IPerson> peopleSortedByName = new SortedSet<IPerson>(new NameComparator());
            SortedSet<IPerson> peopleSortedByAge = new SortedSet<IPerson>(new AgeComparator());

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personArgs = Console.ReadLine().Split();

                string name = personArgs[0];
                int age = int.Parse(personArgs[1]);

                IPerson person = new Person(name, age);
                peopleSortedByName.Add(person);
                peopleSortedByAge.Add(person);
            }

            foreach (var person in peopleSortedByName)
            {
                Console.WriteLine(person);
            }

            foreach (var person in peopleSortedByAge)
            {
                Console.WriteLine(person);
            }
        }
    }
}
