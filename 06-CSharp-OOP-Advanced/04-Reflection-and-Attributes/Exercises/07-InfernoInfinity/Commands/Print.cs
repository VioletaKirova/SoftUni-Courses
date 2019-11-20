namespace _07_InfernoInfinity.Commands
{
    using Contracts;
    using System;
    using System.Linq;

    public class Print : Command
    {
        public Print(string type, string[] data, IWeaponRepository weaponRepository) 
            : base(type, data, weaponRepository)
        {
        }

        public override void Execude()
        {
            string weaponName = this.Data[1];
            IWeapon weapon = this.WeaponRepository.Weapons.FirstOrDefault(w => w.Name == weaponName);

            Console.WriteLine(weapon);
        }
    }
}
