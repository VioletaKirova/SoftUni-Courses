namespace MyApp.Core
{
    using System;
    using System.Linq;

    using Microsoft.Extensions.DependencyInjection;

    using Contracts;

    public class Engine : IEngine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            while (true)
            {
                string[] inputArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var commandInterpreter = this.serviceProvider.GetService<ICommandInterpreter>();

                string result = commandInterpreter.Read(inputArgs);

                Console.WriteLine(result);
            }
        }
    }
}
