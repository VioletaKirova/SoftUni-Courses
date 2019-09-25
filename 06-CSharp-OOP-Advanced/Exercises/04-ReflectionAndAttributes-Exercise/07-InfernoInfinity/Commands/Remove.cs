namespace _07_InfernoInfinity.Commands
{
    using Contracts;
    using System.Linq;

    public class Remove : Command
    {
        public Remove(string type, string[] data, IWeaponRepository weaponRepository) 
            : base(type, data, weaponRepository)
        {
        }

        public override void Execude()
        {
            string weaponName = this.Data[1];
            int socketIndex = int.Parse(this.Data[2]);

            IWeapon weapon = this.WeaponRepository.Weapons.FirstOrDefault(w => w.Name == weaponName);

            weapon.RemoveGem(socketIndex);
        }
    }
}
