namespace _03_Stack
{
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private ICommandInterpreter<int> commandInterpreter;

        public Engine()
        {
            this.commandInterpreter = new CommandInterpreter<int>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (true)
            {
                string[] inputArgs = input
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                string command = inputArgs[0];

                try
                {
                    switch (command)
                    {
                        case "Push":
                            int[] elements = inputArgs
                                .Skip(1)
                                .Select(int.Parse)
                                .ToArray();
                            this.commandInterpreter.Push(elements);
                            break;
                        case "Pop":
                            this.commandInterpreter.Pop();
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
