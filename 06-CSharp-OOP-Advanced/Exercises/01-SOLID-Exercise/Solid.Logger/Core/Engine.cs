namespace Solid.Logger.Core
{
    using Solid.Logger.Core.Contracts;
    using System;

    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                this.commandInterpreter.AddAppender(inputArgs);
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputArgs = input
                    .Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                this.commandInterpreter.AddMessage(inputArgs);

                input = Console.ReadLine();
            }

            this.commandInterpreter.PrintInfo();
        }
    }
}
