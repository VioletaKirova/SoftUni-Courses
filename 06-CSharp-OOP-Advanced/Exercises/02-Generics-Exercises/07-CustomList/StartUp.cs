namespace _07_CustomList
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter<string> commandInterpreter = new CommandInterpreter<string>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputArgs = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string command = inputArgs[0];
                string element = string.Empty;

                try
                {
                    switch (command)
                    {
                        case "Add":
                            element = inputArgs[1];
                            commandInterpreter.Add(element);
                            break;
                        case "Remove":
                            int index = int.Parse(inputArgs[1]);
                            commandInterpreter.Remove(index);
                            break;
                        case "Contains":
                            element = inputArgs[1];
                            commandInterpreter.Contains(element);
                            break;
                        case "Swap":
                            int index1 = int.Parse(inputArgs[1]);
                            int index2 = int.Parse(inputArgs[2]);
                            commandInterpreter.Swap(index1, index2);
                            break;
                        case "Greater":
                            element = inputArgs[1];
                            commandInterpreter.Greater(element);
                            break;
                        case "Max":
                            commandInterpreter.Max();
                            break;
                        case "Min":
                            commandInterpreter.Min();
                            break;
                        case "Print":
                            commandInterpreter.Print();
                            break;
                        case "Sort":
                            commandInterpreter.Sort();
                            break;
                        default:
                            throw new InvalidOperationException("Invalid command!");
                    }
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
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
