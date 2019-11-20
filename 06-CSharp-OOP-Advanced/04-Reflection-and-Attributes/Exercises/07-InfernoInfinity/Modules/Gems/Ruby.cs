namespace _07_InfernoInfinity.Modules.Gems
{
    using Enums;

    public class Ruby : Gem
    {
        private const int defaultStrengthBonus = 7;
        private const int defaultAgilityBonus = 2;
        private const int defaultVitalityBonus = 5;

        public Ruby(Clarity clarityLevel) 
            : base(clarityLevel, defaultStrengthBonus, defaultAgilityBonus, defaultVitalityBonus)
        {
        }
    }
}
