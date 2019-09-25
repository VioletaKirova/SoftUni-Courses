namespace MyApp.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using Contracts;
    using Data;
    using Models;
    using ViewModels;

    public class AddEmployeeCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public AddEmployeeCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            string firstName = inputArgs[0];
            string lastName = inputArgs[1];
            decimal salary = decimal.Parse(inputArgs[2]);

            var employee = new Employee()
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };

            if (!IsValid(employee))
            {
                throw new InvalidOperationException("Invalid employee data!");
            }

            this.context.Employees.Add(employee);
            this.context.SaveChanges();

            var employeeDto = this.mapper.CreateMappedObject<EmployeeDto>(employee);

            string result = $"Successfully registered: {employeeDto.FirstName} {employeeDto.LastName} - {employeeDto.Salary:f2}!";

            return result;
        }

        private static bool IsValid(object entity)
        {
            ValidationContext validationContext = new ValidationContext(entity);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(entity, validationContext, validationResults, true);

            return isValid;
        }
    }
}
