using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _10_StudentGroups
{
    class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
    }

    class Town
    {
        public string Name { get; set; }
        public int SeatsCount { get; set; }
        public List<Student> Students { get; set; }
    }

    class Group
    {
        public Town Town { get; set; }
        public List<Student> Students { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Town> towns = ReadTownsAndStudents();
            List<Group> groups = DistributeStudentsIntoGroups(towns);
            PrintGroups(groups, towns);
        }

        static List<Town> ReadTownsAndStudents()
        {
            var towns = new List<Town>();
            string inputLine = Console.ReadLine();

            while (inputLine != "End")
            {
                if (inputLine.Contains("=>"))
                {
                    Town town = new Town();
                    char[] separators = { ' ', '=', '>' };

                    List<string> inputList = inputLine.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();

                    if (inputList.Count == 3)
                    {
                        town.Name = inputList[0];
                        town.SeatsCount = int.Parse(inputList[1]);
                    }
                    else
                    {
                        town.Name = $"{inputList[0]} {inputList[1]}";
                        town.SeatsCount = int.Parse(inputList[2]);
                    }

                    town.Students = new List<Student>();
                    towns.Add(town);
                }
                else
                {
                    Student student = new Student();
                    char[] separators = { ' ', '|' };
                    List<string> inputList = inputLine.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
                    student.Name = $"{inputLine[0]} {inputLine[1]}";
                    student.Email = inputList[2];
                    student.RegistrationDate = DateTime.ParseExact(inputList[3], "d-MMM-yyyy", CultureInfo.InvariantCulture);
                    towns.Last().Students.Add(student);
                }

                inputLine = Console.ReadLine();
            }

            return towns;
        }

        static List<Group> DistributeStudentsIntoGroups(List<Town> towns)
        {
            var groups = new List<Group>();

            foreach (var town in towns.OrderBy(t => t.Name))
            {
                IEnumerable<Student> students = town.Students
                    .OrderBy(s => s.RegistrationDate)
                    .ThenBy(s => s.Name)
                    .ThenBy(s => s.Email);

                while (students.Any())
                {
                    Group group = new Group();
                    group.Town = town;
                    group.Students = students.Take(group.Town.SeatsCount).ToList();
                    students = students.Skip(group.Town.SeatsCount);
                    groups.Add(group);
                }
            }

            return groups;
        }

        static void PrintGroups(List<Group> groups, List<Town> towns)
        {
            Console.WriteLine($"Created {groups.Count} groups in {towns.Distinct().ToList().Count} towns:");

            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Town.Name} => {string.Join(", ", group.Students.Select(s => s.Email).ToList())}");
            }
        }
    }
}