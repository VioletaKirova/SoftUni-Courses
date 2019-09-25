namespace _07_InfernoInfinity.Modules.Weapons
{
    using Enums;

    public class Knife : Weapon
    {
        private const int defaultMinDamage = 3;
        private const int defaultMaxDamage = 4;
        private const int defaultSockets = 2;

        public Knife(string name, Rarity rarityLevel)
            : base(name, rarityLevel, defaultMinDamage, defaultMaxDamage, defaultSockets)
        {
        }
    }
}
