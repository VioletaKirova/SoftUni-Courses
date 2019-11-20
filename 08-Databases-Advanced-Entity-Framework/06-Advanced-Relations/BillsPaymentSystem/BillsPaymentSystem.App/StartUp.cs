namespace BillsPaymentSystem.App
{
    using Core;
    using Core.Contracts;
    using Data;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
            {
                //DbInitializer.Seed(context);

                ICommandInterpreter commandInterpreter = new CommandInterpreter();
                IEngine engine = new Engine(commandInterpreter);
                engine.Run();
            }
        }
    }
}
