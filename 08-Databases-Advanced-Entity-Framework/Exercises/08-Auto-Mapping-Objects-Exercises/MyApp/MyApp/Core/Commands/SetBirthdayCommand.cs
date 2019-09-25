namespace MyApp.Core.Commands
{
    using System;
    using System.Globalization;

    using AutoMapper;
    using Contracts;
    using Data;
    using ViewModels;

    public class SetBirthdayCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public SetBirthdayCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            int employeeId = int.Parse(inputArgs[0]);
            DateTime birthday = DateTime.ParseExact(inputArgs[1], "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentNullException("Invalid employeeId!");
            }

            employee.Birthday = birthday;
            context.SaveChanges();

            var employeePersonalInfoDto = mapper.CreateMappedObject<EmployeePersonalInfoDto>(employee);

            string result = $"Successfully added birthday: {employeePersonalInfoDto.Birthday.Value.ToString("dd-MM-yyyy")} to employee with ID: {employeePersonalInfoDto.Id}!";

            return result;
        }
    }
}
