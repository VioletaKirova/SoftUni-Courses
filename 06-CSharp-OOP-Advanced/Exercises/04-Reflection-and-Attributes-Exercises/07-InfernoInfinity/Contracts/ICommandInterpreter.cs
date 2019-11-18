namespace _07_InfernoInfinity.Contracts
{
    public interface ICommandInterpreter
    {
        ICommand CreateCommand(string commandType, string[] data, IWeaponRepository weaponRepository);
    }
}
