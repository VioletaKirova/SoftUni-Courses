using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double students = double.Parse(Console.ReadLine());

            double topStudents = 0.0;
            double secondStudents = 0.0;
            double thirdStudents = 0.0;
            double failedStudents = 0.0;
            double sum = 0.0;

            for (int i = 0; i < students; i++)
            {
                double grade = double.Parse(Console.ReadLine());

                sum += grade;

                if (grade >= 2 && grade <= 2.99)
                {
                    failedStudents++;
                }
                else if (grade >= 3 && grade <= 3.99)
                {
                    thirdStudents++;
                }
                else if (grade >= 4 && grade <= 4.99)
                {
                    secondStudents++;
                }
                else if (grade >= 5)
                {
                    topStudents++;
                }
            }

            double percentTopStudents = topStudents / students * 100;
            double percentSecondStudents = secondStudents / students * 100;
            double percentThirdStudents = thirdStudents / students * 100;
            double percentFailedStudents = failedStudents / students * 100;
            double average = sum / students;

            Console.WriteLine($"Top students: {percentTopStudents:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {percentSecondStudents:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {percentThirdStudents:f2}%");
            Console.WriteLine($"Fail: {percentFailedStudents:f2}%");
            Console.WriteLine($"Average: {average:f2}");
        }
    }
}
