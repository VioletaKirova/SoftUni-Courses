namespace MyApp.Core.Commands
{
    using System;
    using System.Text;

    using AutoMapper;
    using Contracts;
    using Data;
    using ViewModels;

    class EmployeePersonalInfoCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public EmployeePersonalInfoCommand(MyAppContext context, Mapper mapper)
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

            var employeeDto = mapper.CreateMappedObject<EmployeePersonalInfoDto>(employee);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"ID: {employeeDto.Id} - {employeeDto.FirstName} {employeeDto.LastName} - ${employeeDto.Salary:f2}");
            sb.AppendLine($"Birthday: {employeeDto.Birthday.Value.ToString("dd-MM-yyyy")}");
            sb.AppendLine($"Address: {employeeDto.Address}");

            string result = sb.ToString().TrimEnd();

            return result;
        }
    }
}
