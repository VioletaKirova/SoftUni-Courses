namespace _07_InfernoInfinity.Core
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        public ICommand CreateCommand(string commandType, string[] data, IWeaponRepository weaponRepository)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == commandType);
            ICommand instance = (ICommand)Activator.CreateInstance(type, new object[] { commandType, data, weaponRepository });

            return instance;
        }
    }
}
