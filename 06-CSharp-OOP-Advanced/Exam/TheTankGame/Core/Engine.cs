namespace TheTankGame.Core
{
    using System;
    using Contracts;
    using IO.Contracts;
    using System.Collections.Generic;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader, 
            IWriter writer, 
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

            this.isRunning = true;
        }

        public void Run()
        {
            while (isRunning)
            {
                IList<string> inputParameters = this.reader.ReadLine().Split();
                string result = this.commandInterpreter.ProcessInput(inputParameters);
                this.writer.WriteLine(result);

                if (inputParameters[0] == "Terminate")
                {
                    isRunning = false;
                }
            }
        }
    }
}