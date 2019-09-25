namespace _07_InfernoInfinity.Data
{
    using Contracts;
    using System.Collections.Generic;

    public class WeaponRepository : IWeaponRepository
    {
        public WeaponRepository()
        {
            this.Weapons = new List<IWeapon>();
        }

        public List<IWeapon> Weapons { get; private set; }
    }
}
