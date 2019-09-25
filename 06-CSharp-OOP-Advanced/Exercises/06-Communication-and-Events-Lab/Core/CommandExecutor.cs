namespace Heroes.Core
{
    using Commands.Contracts;
    using Contracts;

    public class CommandExecutor : IExecutor
    {
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
        }
    }
}
