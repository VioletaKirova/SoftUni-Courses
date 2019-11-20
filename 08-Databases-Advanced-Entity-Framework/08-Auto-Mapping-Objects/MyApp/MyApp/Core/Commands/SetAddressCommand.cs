namespace MyApp.Core.Commands
{
    using System;

    using AutoMapper;
    using Contracts;
    using Data;
    using ViewModels;

    public class SetAddressCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public SetAddressCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            int employeeId = int.Parse(inputArgs[0]);
            string address = inputArgs[1];

            var employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentNullException("Invalid employeeId!");
            }

            employee.Address = address;
            context.SaveChanges();

            var employeePersonalInfoDto = mapper.CreateMappedObject<EmployeePersonalInfoDto>(employee); 

            string result = $"Successfully added address: {employeePersonalInfoDto.Address} to employee with ID: {employeePersonalInfoDto.Id}!";

            return result;
        }
    }
}
