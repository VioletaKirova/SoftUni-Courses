namespace _07_InfernoInfinity.Core
{
    using Contracts;
    using System;

    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(IWeaponRepository weaponRepository )
        {
            this.WeaponRepository = weaponRepository;
            this.commandInterpreter = new CommandInterpreter();
        }

        public IWeaponRepository WeaponRepository { get; private set; }       

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] data = input
                    .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                string commandType = data[0];

                ICommand command = this.commandInterpreter.CreateCommand(commandType, data, this.WeaponRepository);
                command.Execude();

                input = Console.ReadLine();
            }
        }
    }
}
