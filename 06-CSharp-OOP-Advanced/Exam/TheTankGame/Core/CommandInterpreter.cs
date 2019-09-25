namespace TheTankGame.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IManager tankManager;

        public CommandInterpreter(IManager tankManager)
        {
            this.tankManager = tankManager;
        }

        public string ProcessInput(IList<string> inputParameters)
        {
            string command = inputParameters[0];
            IList<string> commandParams = inputParameters.Skip(1).ToList();

            if (command == "Vehicle" || command == "Part")
            {
                command = "Add" + command;
            }

            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == "IManager");
            var method = type.GetMethod(command, BindingFlags.Instance | BindingFlags.Public);
            var result = method.Invoke(this.tankManager, new object[] { commandParams });

            //string result = string.Empty;

            //switch (command)
            //{
            //    case "Vehicle":
            //        result = this.tankManager.AddVehicle(commandParams);
            //        break;
            //    case "Part":
            //        result = this.tankManager.AddPart(commandParams);
            //        break;
            //    case "Inspect":
            //        result = this.tankManager.Inspect(commandParams);
            //        break;
            //    case "Battle":
            //        result = this.tankManager.Battle(commandParams);
            //        break;
            //    case "Terminate":
            //        result = this.tankManager.Terminate(commandParams);
            //        break;
            //}

            return result.ToString();
        }
    }
}