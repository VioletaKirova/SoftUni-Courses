namespace _07_InfernoInfinity.Contracts
{
    using Enums;

    public interface IWeapon
    {
        string Name { get; }

        Rarity RarityLevel { get; }

        int MinDamage { get; }

        int MaxDamage { get; }

        int Sockets { get; }

        IGem[] Gems { get; }

        void AddGem(int socketIndex, IGem gemToAdd);

        void RemoveGem(int socketIndex);
    }
}