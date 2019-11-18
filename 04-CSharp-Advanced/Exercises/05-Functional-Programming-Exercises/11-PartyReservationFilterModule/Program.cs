using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> addedFilters = new Dictionary<string, List<string>>();

            Action<List<string>> print = x => Console.WriteLine(string.Join(' ', x));

            Func<string, List<string>, string> findFilter = (param, names) => 
            names.FirstOrDefault(x => x == param);

            List<string> inputNames = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "Print")
            {
                string[] commandArgs = input.Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = commandArgs[0];
                string filter = commandArgs[1];
                string parameter = commandArgs[2];

                if (command == "Add filter")
                {
                    if (!addedFilters.ContainsKey(filter))
                    {
                        addedFilters[filter] = new List<string>();
                    }

                    addedFilters[filter].Add(parameter);
                }
                else if (command == "Remove filter")
                {
                    string filterForRemoval = findFilter(parameter, addedFilters[filter]);

                    int indexForRemoval = addedFilters[filter].IndexOf(filterForRemoval);

                    addedFilters[filter].RemoveAt(indexForRemoval);
                }

                input = Console.ReadLine();
            }

            foreach (var filter in addedFilters)
            {
                if (filter.Key == "Starts with")
                {
                    foreach (var v in filter.Value)
                    {
                        inputNames.RemoveAll(x => x.StartsWith(v));
                    }
                }
                else if (filter.Key == "Ends with")
                {
                    foreach (var v in filter.Value)
                    {
                        inputNames.RemoveAll(x => x.EndsWith(v));
                    }
                }
                else if (filter.Key == "Length")
                {
                    foreach (var v in filter.Value)
                    {
                        inputNames.RemoveAll(x => x.Length == int.Parse(v));
                    }
                }
                else if (filter.Key == "Contains")
                {
                    foreach (var v in filter.Value)
                    {
                        inputNames.RemoveAll(x => x.Contains(v));
                    }
                }
            }

            print(inputNames);
        }
    }
}
