namespace _07_InfernoInfinity.Contracts
{
    public interface IEngine
    {
        IWeaponRepository WeaponRepository { get; }

        void Run();
    }
}
