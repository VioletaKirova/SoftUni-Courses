namespace _07_InfernoInfinity.Modules.Weapons
{
    using Enums;

    public class Axe : Weapon
    {
        private const int defaultMinDamage = 5;
        private const int defaultMaxDamage = 10;
        private const int defaultSockets = 4;

        public Axe(string name, Rarity rarityLevel) 
            : base(name, rarityLevel, defaultMinDamage, defaultMaxDamage, defaultSockets)
        {
        }
    }
}
