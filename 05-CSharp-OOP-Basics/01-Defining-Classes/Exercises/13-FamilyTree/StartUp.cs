using System;
using System.Collections.Generic;
using System.Linq;

namespace _13_FamilyTree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<string> relationships = new List<string>();

            string name = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "End")
            {
                if (input.Contains('-'))
                {
                    relationships.Add(input);
                }
                else
                {
                    string[] inputArgs = input
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string personName = inputArgs[0] + " " + inputArgs[1];
                    string personBirthday = inputArgs[2];

                    Person person = new Person(personName, personBirthday);
                    people.Add(person);
                }

                input = Console.ReadLine();
            }

            foreach (var relationship in relationships)
            {
                string[] relationshipArgs = relationship
                    .Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string parentStr = relationshipArgs[0];
                string childStr = relationshipArgs[1];

                Person parent;
                Person child;

                if (parentStr.Contains('/'))
                {
                    parent = people.Where(p => p.Birthday == parentStr).FirstOrDefault();
                }
                else
                {
                    parent = people.Where(p => p.Name == parentStr).FirstOrDefault();                  
                }

                if (childStr.Contains('/'))
                {
                    child = people.Where(p => p.Birthday == childStr).FirstOrDefault();
                }
                else
                {
                    child = people.Where(p => p.Name == childStr).FirstOrDefault();
                }

                parent.Children.Add(child);
                child.Parents.Add(parent);
            }

            Person personForOutput;

            if (name.Contains('/'))
            {
                personForOutput = people.Where(p => p.Birthday == name).FirstOrDefault();
            }
            else
            {
                personForOutput = people.Where(p => p.Name == name).FirstOrDefault();
            }

            Console.WriteLine($"{personForOutput.Name} {personForOutput.Birthday}");

            Console.WriteLine("Parents:");
            foreach (var parent in personForOutput.Parents)
            {
                Console.WriteLine($"{parent.Name} {parent.Birthday}");
            }

            Console.WriteLine("Children:");
            foreach (var child in personForOutput.Children)
            {
                Console.WriteLine($"{child.Name} {child.Birthday}");
            }
        }
    }
}
