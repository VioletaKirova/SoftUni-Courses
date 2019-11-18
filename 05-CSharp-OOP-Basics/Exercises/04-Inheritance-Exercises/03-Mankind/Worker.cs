using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Mankind
{
    public class Worker : Human
    {
        private const int MIN_WEEK_SALARY = 10;
        private const int WORK_DAYS = 5;
        private const int MIN_WORK_HOURS = 1;
        private const int MAX_WORK_HOURS = 12;

        private decimal weekSalary;
        private decimal workHoursPerDay;
        private decimal salaryPerHour;

        public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get { return weekSalary; }
            set
            {
                if (value <= MIN_WEEK_SALARY)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                weekSalary = value;
            }
        }

        public decimal WorkHoursPerDay
        {
            get { return workHoursPerDay; }
            set
            {
                if (value < MIN_WORK_HOURS || value > MAX_WORK_HOURS)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }

                workHoursPerDay = value;
            }
        }

        public decimal SalaryPerHour
        {
            get { return salaryPerHour = (this.WeekSalary / WORK_DAYS) / this.WorkHoursPerDay; }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"First Name: {this.FirstName}")
               .AppendLine($"Last Name: {this.LastName}")
               .AppendLine($"Week Salary: {this.WeekSalary:f2}")
               .AppendLine($"Hours per day: {this.WorkHoursPerDay:f2}")
               .AppendLine($"Salary per hour: {this.SalaryPerHour:f2}");

            return result.ToString().TrimEnd();
        }
    }
}
