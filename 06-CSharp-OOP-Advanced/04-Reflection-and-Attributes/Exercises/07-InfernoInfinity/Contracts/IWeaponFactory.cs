namespace _07_InfernoInfinity.Contracts
{
    using Enums;

    public interface IWeaponFactory
    {
        IWeapon CreateWeapon(string weaponType, string[] data, string name, Rarity rarity);
    }
}
