namespace MyApp.Core.Commands
{
    using System;

    using Contracts;

    public class ExitCommand : ICommand
    {
        public string Execute(string[] inputArgs)
        {
            Environment.Exit(0);

            return string.Empty;
        }
    }
}
