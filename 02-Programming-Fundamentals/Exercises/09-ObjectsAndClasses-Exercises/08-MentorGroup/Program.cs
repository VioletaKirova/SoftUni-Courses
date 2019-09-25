using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _08_MentorGroup
{
    // 20/100
    class Program
    {
        class Student
        {
            public string Name { get; set; }
            public List<String> Comments { get; set; }
            public List<DateTime> Attendancy { get; set; }
        }

        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            string input = Console.ReadLine();

            while (input != "end of dates")
            {
                List<string> inputData = input.Split(' ', ',').ToList();

                string name = inputData[0];

                Student student = new Student();

                if (!students.Any(s => s.Name == name))
                {
                    student.Name = name;
                    students.Add(student);
                }

                if (inputData.Count > 1)
                {
                    student.Attendancy = new List<DateTime>();

                    for (int i = 1; i < inputData.Count; i++)
                    {
                        student.Attendancy.Add(DateTime.ParseExact(inputData[i], "dd/MM/yyyy", CultureInfo.InvariantCulture));
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var student in students)
            {
                student.Comments = new List<string>();
            }

            while (input != "end of comments")
            {
                input = Console.ReadLine();
                List<string> inputData = input.Split('-').ToList();                
                string name = inputData[0];

                if (!students.Any(s => s.Name == name))
                {
                    continue;
                }         
                
                foreach (var student in students)
                {
                    if (name == student.Name)
                    {
                        student.Comments.Add(inputData[1]);
                    }
                }
            }

            foreach (var student in students.OrderBy(s => s.Name))
            {
                Console.WriteLine(student.Name);
                Console.WriteLine("Comments:");

                foreach (var comment in student.Comments)
                {
                    Console.WriteLine($"- {comment}");
                }

                Console.WriteLine("Dates attended:");

                foreach (var date in student.Attendancy.OrderBy(d => d))
                {
                    Console.WriteLine($"-- {date:dd/MM/yyyy}");
                }
            }
        }
    }
}