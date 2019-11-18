using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03_Mankind
{
    public class Student : Human
    {
        private const int MIN_LEN = 5;
        private const int MAX_LEN = 10;

        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            :base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return facultyNumber; }
            set
            {
                if (value.Length < MIN_LEN || value.Length > MAX_LEN || !value.All(char.IsLetterOrDigit))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                facultyNumber = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"First Name: {this.FirstName}")
                .AppendLine($"Last Name: {this.LastName}")
                .AppendLine($"Faculty number: {this.FacultyNumber}");

            return result.ToString().TrimEnd();
        }
    }
}
