namespace MyApp.Core.Commands
{
    using System;

    using Contracts;
    using Data;

    public class SetManagerCommand : ICommand
    {
        private readonly MyAppContext context;

        public SetManagerCommand(MyAppContext context)
        {
            this.context = context;
        }

        public string Execute(string[] inputArgs)
        {
            var employeeId = int.Parse(inputArgs[0]);
            var managerId = int.Parse(inputArgs[1]);

            var employee = context.Employees.Find(employeeId);
            var manager = context.Employees.Find(managerId);

            if (employee == null || manager == null)
            {
                throw new ArgumentNullException("Invalid employeeId or managerId!");
            }

            employee.Manager = manager;
            context.SaveChanges();

            string result = $"Command completed successfully!";

            return result;
        }
    }
}
