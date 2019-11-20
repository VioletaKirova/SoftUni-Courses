namespace _01_02_ListyIterator
{
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private CommandInterpreter<string> commandInterpreter;

        public Engine()
        {
            this.commandInterpreter = new CommandInterpreter<string>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (true)
            {
                string[] inputArgs = input.Split();

                string command = inputArgs[0];

                try
                {
                    switch (command)
                    {
                        case "Create":
                            string[] elements = inputArgs.Skip(1).ToArray();
                            this.commandInterpreter.Create(elements);
                            break;
                        case "Move":
                            this.commandInterpreter.Move();
                            break;
                        case "Print":
                            this.commandInterpreter.Print();
                            break;
                        case "HasNext":
                            this.commandInterpreter.HasNext();
                            break;
                        case "PrintAll":
                            this.commandInterpreter.PrintAll();
                            break;
                        case "END":
                            this.commandInterpreter.END();
                            break;
                        default:
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }
        }
    }
}
