namespace _07_InfernoInfinity.Commands
{
    using Contracts;
    using Enums;
    using System;

    public class Create : Command
    {
        public Create(string type, string[] data, IWeaponRepository weaponRepository) 
            : base(type, data, weaponRepository)
        {
        }

        public override void Execude()
        {
            string[] weaponTypeArgs = this.Data[1].Split();
            string levelOfRarity = weaponTypeArgs[0];
            string weaponType = weaponTypeArgs[1];
            string weaponName = this.Data[2];
            Rarity rarity = (Rarity)Enum.Parse(typeof(Rarity), levelOfRarity);

            IWeapon weapon = this.WeaponFactory.CreateWeapon(weaponType, this.Data, weaponName, rarity);

            this.WeaponRepository.Weapons.Add(weapon);
        }
    }
}
