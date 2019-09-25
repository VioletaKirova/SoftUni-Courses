namespace Solid.Logger
{
    using Solid.Logger.Core;
    using Solid.Logger.Core.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IEngine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
