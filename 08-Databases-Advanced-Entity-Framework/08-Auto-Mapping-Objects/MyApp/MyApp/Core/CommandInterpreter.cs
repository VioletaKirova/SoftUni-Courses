namespace MyApp.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Microsoft.Extensions.DependencyInjection;

    using Commands.Contracts;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Suffix = "Command";
        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string Read(string[] inputArgs)
        {
            string commandName = inputArgs[0] + Suffix;
            string[] commandParams = inputArgs.Skip(1).ToArray();

            var type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == commandName);

            if (type == null)
            {
                //throw new ArgumentNullException("Ivalid command!");
                return "Ivalid command!";
            }

            var constructor = type
                .GetConstructors()
                .FirstOrDefault();

            var contructorParams = constructor
                .GetParameters()
                .Select(x => x.ParameterType)
                .ToArray();

            var services = contructorParams
                .Select(this.serviceProvider.GetService)
                .ToArray();

            var command = (ICommand)Activator.CreateInstance(type, services);

            string result = command.Execute(commandParams);

            return result;
        }
    }
}
