namespace _07_InfernoInfinity.Modules.Gems
{
    using Enums;

    public class Amethyst : Gem
    {
        private const int defaultStrengthBonus = 2;
        private const int defaultAgilityBonus = 8;
        private const int defaultVitalityBonus = 4;

        public Amethyst(Clarity clarityLevel)
            : base(clarityLevel, defaultStrengthBonus, defaultAgilityBonus, defaultVitalityBonus)
        {
        }
    }
}
