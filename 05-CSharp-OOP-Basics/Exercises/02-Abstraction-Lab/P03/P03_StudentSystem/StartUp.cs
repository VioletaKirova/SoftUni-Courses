using System;
using System.Collections.Generic;

namespace P03_StudentSystem
{
    class StartUp
    {
        static void Main()
        {
            var studentSystem = new Dictionary<string, Student>();

            while (true)
            {
                string[] commandArgs = Console.ReadLine().Split();

                ReadCommand(studentSystem, commandArgs);
            }
        }

        private static void ReadCommand(Dictionary<string, Student> studentSystem, string[] commandArgs)
        {
            if (commandArgs[0] == "Create")
            {
                CreateStudent(studentSystem, commandArgs);
            }
            else if (commandArgs[0] == "Show")
            {
                GetStudentInfo(studentSystem, commandArgs);

            }
            else if (commandArgs[0] == "Exit")
            {
                Environment.Exit(0);
            }
        }

        private static void GetStudentInfo(Dictionary<string, Student> studentSystem, string[] commandArgs)
        {
            var name = commandArgs[1];

            if (studentSystem.ContainsKey(name))
            {
                PrintStudentInfo(studentSystem, name);
            }
        }

        private static void PrintStudentInfo(Dictionary<string, Student> studentSystem, string name)
        {
            var student = studentSystem[name];

            string info = $"{student.Name} is {student.Age} years old.";

            if (student.Grade >= 5.00)
            {
                info += " Excellent student.";
            }
            else if (student.Grade < 5.00 && student.Grade >= 3.50)
            {
                info += " Average student.";
            }
            else
            {
                info += " Very nice person.";
            }

            Console.WriteLine(info);
        }

        private static void CreateStudent(Dictionary<string, Student> studentSystem, string[] commandArgs)
        {
            var name = commandArgs[1];
            var age = int.Parse(commandArgs[2]);
            var grade = double.Parse(commandArgs[3]);

            if (!studentSystem.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                studentSystem[name] = student;
            }
        }
    }
}
