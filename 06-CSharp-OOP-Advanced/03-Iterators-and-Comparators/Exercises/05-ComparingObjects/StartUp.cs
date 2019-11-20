namespace _05_ComparingObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IList<IPerson> people = new List<IPerson>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputArgs = input.Split();

                IPerson person = new Person(inputArgs[0], int.Parse(inputArgs[1]), inputArgs[2]);
                people.Add(person);

                input = Console.ReadLine();
            }

            int index = int.Parse(Console.ReadLine());
            IPerson personForComparison = people[index - 1];

            int equalPeope = people.Where(x => x.CompareTo(personForComparison) == 0).Count();

            if (equalPeope == 1)
            {
                Console.WriteLine("No matches");
                return;
            }

            int notEqualPeope = people.Count - equalPeope;

            Console.WriteLine($"{equalPeope} {notEqualPeope} {people.Count}");
        }
    }
}
