namespace _07_InfernoInfinity.Modules.Gems
{
    using Enums;

    public class Emerald : Gem
    {
        private const int defaultStrengthBonus = 1;
        private const int defaultAgilityBonus = 4;
        private const int defaultVitalityBonus = 9;

        public Emerald(Clarity clarityLevel)
            : base(clarityLevel, defaultStrengthBonus, defaultAgilityBonus, defaultVitalityBonus)
        {
        }
    }
}
