namespace MyApp.Core.Commands
{
    using System;

    using AutoMapper;
    using Contracts;
    using Data;
    using ViewModels;

    public class EmployeeInfoCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public EmployeeInfoCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            int employeeId = int.Parse(inputArgs[0]);
            var employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentNullException("Invalid employeeId!");
            }

            var employeeDto = mapper.CreateMappedObject<EmployeeDto>(employee);

            string result = $"ID: {employeeDto.Id} - {employeeDto.FirstName} {employeeDto.LastName} - ${employeeDto.Salary:f2}";

            return result;
        }
    }
}
