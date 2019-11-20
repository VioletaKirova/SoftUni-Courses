namespace P03.DetailPrinter
{
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            IList<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Pesho"));
            employees.Add(new Manager("Sasho", new string[] { "Akt za rajdane", "Diploma ot TU-to"}));

            DetailsPrinter detailsPrinter = new DetailsPrinter(employees);

            detailsPrinter.PrintDetails();
        }
    }
}
