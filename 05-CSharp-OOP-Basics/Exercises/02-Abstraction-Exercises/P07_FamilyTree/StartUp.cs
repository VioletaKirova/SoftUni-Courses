using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_FamilyTree
{
    // 20/100

    public class StartUp
    {
        static void Main(string[] args)
        {
            var familyTree = new List<Person>();

            string personInput = Console.ReadLine();

            Person mainPerson = new Person();

            if (IsBirthday(personInput))
            {
                mainPerson.Birthday = personInput;
            }
            else
            {
                mainPerson.Name = personInput;
            }

            familyTree.Add(mainPerson);

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                // Split by " - " to get the relationships
                string[] tokens = command.Split(" - ");

                if (tokens.Length > 1)
                {
                    string parent = tokens[0];
                    string child = tokens[1];

                    Person currentPerson;

                    if (IsBirthday(parent))
                    {
                        currentPerson = familyTree.FirstOrDefault(p => p.Birthday == parent);

                        if (currentPerson == null)
                        {
                            currentPerson = AddToFamilyTree(familyTree, parent);
                        }

                        SetChild(familyTree, currentPerson, child);
                    }
                    else
                    {
                        currentPerson = familyTree.FirstOrDefault(p => p.Name == parent);

                        if (currentPerson == null)
                        {
                            currentPerson = AddToFamilyTree(familyTree, parent);
                        }

                        SetChild(familyTree, currentPerson, child);
                    }
                }
                else
                {
                    // Get the single names or birthdays to add to the family tree
                    tokens = tokens[0].Split();

                    string name = $"{tokens[0]} {tokens[1]}";
                    string birthday = tokens[2];

                    var person = familyTree.FirstOrDefault(p => p.Name == name ||
                                                           p.Birthday == birthday);

                    if (person == null)
                    {
                        person = new Person();
                        familyTree.Add(person);
                    }

                    person.Name = name;
                    person.Birthday = birthday;

                    int index = familyTree.IndexOf(person) + 1;
                    int count = familyTree.Count - index;

                    Person[] copy = new Person[count];
                    familyTree.CopyTo(index, copy, 0, count);

                    // Check if the person already exists in the family tree
                    Person copyPerson = copy.FirstOrDefault(p => p.Name == name || p.Birthday == birthday);

                    if (copyPerson != null)
                    {
                        familyTree.Remove(copyPerson);

                        person.Parents.AddRange(copyPerson.Parents);
                        person.Parents = person.Parents.Distinct().ToList();

                        person.Children.AddRange(copyPerson.Children);
                        person.Children = person.Children.Distinct().ToList();
                    }
                }
            }

            Console.WriteLine(mainPerson);

            Console.WriteLine("Parents:");
            foreach (var p in mainPerson.Parents)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("Children:");
            foreach (var c in mainPerson.Children)
            {
                Console.WriteLine(c);
            }
        }

        private static Person AddToFamilyTree(List<Person> familyTree, string parent)
        {
            Person currentPerson = new Person();
            currentPerson.Birthday = parent;
            familyTree.Add(currentPerson);
            return currentPerson;
        }

        private static void SetChild(List<Person> familyTree, Person parentPerson, string child)
        {
            var childPerson = new Person();

            if (IsBirthday(child))
            {
                if (!familyTree.Any(p => p.Birthday == child))
                {
                    childPerson.Birthday = child;
                }
                else
                {
                    childPerson = familyTree.First(p => p.Birthday == child);
                }
            }
            else
            {
                if (!familyTree.Any(p => p.Name == child))
                {
                    childPerson.Name = child;
                }
                else
                {
                    childPerson = familyTree.First(p => p.Name == child);
                }
            }

            parentPerson.Children.Add(childPerson);
            childPerson.Parents.Add(parentPerson);
            familyTree.Add(childPerson);
        }

        static bool IsBirthday(string input)
        {
            return Char.IsDigit(input[0]);
        }
    }
}
