namespace _07_InfernoInfinity.Modules.Weapons
{
    using Enums;

    public class Sword : Weapon
    {
        private const int defaultMinDamage = 4;
        private const int defaultMaxDamage = 6;
        private const int defaultSockets = 3;

        public Sword(string name, Rarity rarityLevel)
            : base(name, rarityLevel, defaultMinDamage, defaultMaxDamage, defaultSockets)
        {
        }
    }
}
