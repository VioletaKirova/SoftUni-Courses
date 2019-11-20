namespace _07_InfernoInfinity.Commands
{
    using Contracts;
    using Enums;
    using System;
    using System.Linq;

    public class Add : Command
    {
        public Add(string type, string[] data, IWeaponRepository weaponRepository) 
            : base(type, data, weaponRepository)
        {
        }

        public override void Execude()
        {
            string weaponName = this.Data[1];
            int socketIndex = int.Parse(this.Data[2]);
            string[] gemTypeArgs = this.Data[3].Split();
            string levelOfClarity = gemTypeArgs[0];
            string gemType = gemTypeArgs[1];
            Clarity clarity = (Clarity)Enum.Parse(typeof(Clarity), levelOfClarity);
           
            IGem gem = this.GemFactory.CreateGem(gemType, clarity);

            IWeapon weapon = this.WeaponRepository.Weapons.FirstOrDefault(w => w.Name == weaponName);
            weapon.AddGem(socketIndex, gem);
        }
    }
}
