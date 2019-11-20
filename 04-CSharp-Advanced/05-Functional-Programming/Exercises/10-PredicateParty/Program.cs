using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Predicate<string> predicate;

            string[] command = Console.ReadLine().Split();

            while (command[0] != "Party!")
            {
                string commandName = command[0];
                string criteria = command[1];
                string value = command[2];

                predicate = CheckCriteria(criteria, value);

                if (commandName == "Remove")
                {
                    guests.RemoveAll(predicate);
                }
                else if (commandName == "Double")
                {
                    List<string> guestsToDouble = guests.FindAll(predicate);

                    foreach (var guest in guestsToDouble)
                    {
                        int indexOfGuest = guests.IndexOf(guest);

                        guests.Insert(indexOfGuest + 1, guest);
                    }
                }

                command = Console.ReadLine().Split();
            }

            if (guests.Count > 0)
            {
                Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Predicate<string> CheckCriteria(string criteria, string value)
        {
            if (criteria == "StartsWith")
            {
                return g => g.StartsWith(value);
            }
            else if (criteria == "EndsWith")
            {
                return g => g.EndsWith(value);
            }
            else if (criteria == "Length")
            {
                return g => g.Length == int.Parse(value);
            }

            return null;
        }
    }
}
