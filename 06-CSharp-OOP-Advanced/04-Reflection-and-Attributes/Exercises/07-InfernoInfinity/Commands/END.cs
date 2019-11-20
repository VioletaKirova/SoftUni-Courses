namespace _07_InfernoInfinity.Commands
{
    using Contracts;
    using System;

    public class END : Command
    {
        public END(string type, string[] data, IWeaponRepository weaponRepository) 
            : base(type, data, weaponRepository)
        {
        }

        public override void Execude()
        {
            Environment.Exit(0);
        }
    }
}
