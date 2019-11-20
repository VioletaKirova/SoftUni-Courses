namespace Heroes.Core.Contracts
{
    using Commands.Contracts;

    public interface IExecutor
    {
        void ExecuteCommand(ICommand command);
    }
}
