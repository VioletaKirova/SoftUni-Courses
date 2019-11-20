namespace _07_InfernoInfinity.Contracts
{
    using Factories;

    public interface ICommand
    {
        string Type { get; }

        string[] Data { get; }

        IWeaponRepository WeaponRepository { get; }

        WeaponFactory WeaponFactory { get; }

        void Execude();
    }
}
