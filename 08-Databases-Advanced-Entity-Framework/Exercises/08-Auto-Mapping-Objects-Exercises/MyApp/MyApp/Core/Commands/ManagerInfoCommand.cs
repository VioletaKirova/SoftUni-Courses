namespace MyApp.Core.Commands
{
    using System;
    using System.Linq;
    using System.Text;

    using Microsoft.EntityFrameworkCore;

    using AutoMapper;
    using Contracts;
    using Data;
    using ViewModels;

    public class ManagerInfoCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public ManagerInfoCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            int managerId = int.Parse(inputArgs[0]);

            var manager = context.Employees
                .Include(e => e.ManagedEmployees)
                .FirstOrDefault(e => e.Id == managerId);

            if (manager == null)
            {
                throw new ArgumentNullException("Ivalid managerId!");
            }

            var managerDto = this.mapper.CreateMappedObject<ManagerDto>(manager);


            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{manager.FirstName} {manager.LastName} | Employees: {manager.ManagedEmployees.Count()}");

            foreach (var employee in manager.ManagedEmployees)
            {
                sb.AppendLine($"    - {employee.FirstName} {employee.LastName} - ${employee.Salary:f2}");
            }

            string result = sb.ToString().TrimEnd();

            return result;
        }
    }
}
