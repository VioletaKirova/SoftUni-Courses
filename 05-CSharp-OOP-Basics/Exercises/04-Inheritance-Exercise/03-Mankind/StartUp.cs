using System;

namespace _03_Mankind
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            string[] studentInfo = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string studentFirstName = studentInfo[0];
            string studentLastName = studentInfo[1];
            string studentFacultyNumber = studentInfo[2];

            string[] workerInfo = Console.ReadLine()
                   .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string workerFirstName = workerInfo[0];
            string workerLastName = workerInfo[1];
            decimal workerWeekSalary = decimal.Parse(workerInfo[2]);
            decimal workerWorkHoursPerDay = decimal.Parse(workerInfo[3]);

            try
            {
                Student student = new Student(studentFirstName, studentLastName, studentFacultyNumber);                
                Worker worker = new Worker(workerFirstName, workerLastName, workerWeekSalary, workerWorkHoursPerDay);

                Console.WriteLine(student + Environment.NewLine);
                Console.WriteLine(worker);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
