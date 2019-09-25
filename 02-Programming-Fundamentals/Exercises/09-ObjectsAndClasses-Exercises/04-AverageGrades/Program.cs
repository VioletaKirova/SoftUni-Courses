using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_AverageGrades
{
    class Program
    {
        class Student
        {
            public string Name;
            public double[] Grades;
            public double AverageGrade;
        }

        static void PrintStudents(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name} -> {student.AverageGrade:f2}");
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();
                Student student = new Student();
                student.Name = input[0];
                student.Grades = new double[input.Length - 1];

                for (int j = 1; j < input.Length; j++)
                {
                    student.Grades[j - 1] = (double.Parse(input[j]));
                }

                student.AverageGrade = student.Grades.Average();
                students.Add(student);
            }

            students = students.Where(s => s.AverageGrade >= 5).OrderBy(s => s.Name).ThenBy(s => -s.AverageGrade).ToList();
            PrintStudents(students);
        }
    }
}