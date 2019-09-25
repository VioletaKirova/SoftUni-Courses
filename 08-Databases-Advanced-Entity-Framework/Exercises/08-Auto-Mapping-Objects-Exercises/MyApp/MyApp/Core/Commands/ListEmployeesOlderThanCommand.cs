namespace MyApp.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using Contracts;
    using Data;
    using ViewModels;

    public class ListEmployeesOlderThanCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public ListEmployeesOlderThanCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            var age = int.Parse(inputArgs[0]);

            var currentDate = int.Parse(DateTime.Now.ToString("ddMMyyyy"));

            var employees = context.Employees
                .Where(e => e.Birthday != null && (((currentDate - int.Parse(e.Birthday.Value.ToString("ddMMyyyy"))) / 10000) > age))
                .ToList();

            var employeeManagerDtos = new List<EmployeeManagerDto>();

            foreach (var employee in employees)
            {
                employeeManagerDtos.Add(mapper.CreateMappedObject<EmployeeManagerDto>(employee));
            }

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employeeManagerDtos)
            {
                sb.Append($"{employee.FirstName} {employee.LastName} - ${employee.Salary:f2} - Manager: ");

                if (employee.Manager == null)
                {
                    sb.AppendLine("[no manager]");
                }
                else
                {
                    sb.AppendLine($"{employee.Manager.LastName}");
                }
            }

            string result = sb.ToString().TrimEnd();

            return result;
        }
    }
}
