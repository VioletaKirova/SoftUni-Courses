using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');

                string studentName = input[0];
                double studentGrade = double.Parse(input[1]);

                if (!students.ContainsKey(studentName))
                {
                    students[studentName] = new List<double>();
                }

                students[studentName].Add(studentGrade);
            }

            foreach (var student in students)
            {
                string name = student.Key;
                double averageGrade = student.Value.Average();

                Console.Write($"{name} -> ");

                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }

                Console.Write($"(avg: {averageGrade:f2})");
                Console.WriteLine();
            }
        }
    }
}
