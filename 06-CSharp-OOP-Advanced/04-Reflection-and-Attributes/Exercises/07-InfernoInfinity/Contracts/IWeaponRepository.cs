namespace _07_InfernoInfinity.Contracts
{
    using System.Collections.Generic;

    public interface IWeaponRepository
    {
        List<IWeapon> Weapons { get; }
    }
}
