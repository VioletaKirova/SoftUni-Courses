namespace _07_InfernoInfinity.Modules.Gems
{
    using Contracts;
    using Enums;

    public abstract class Gem : IGem
    {
        private Clarity clarityLevel;
        private int strengthBonus;
        private int agilityBonus;
        private int vitalityBonus;

        public Gem(Clarity clarityLevel,int strengthBonus, int agilityBonus, int vitalityBonus)
        {
            this.ClarityLevel = clarityLevel;
            this.StrengthBonus = strengthBonus;
            this.AgilityBonus = agilityBonus;
            this.VitalityBonus = vitalityBonus;
        }

        public Clarity ClarityLevel
        {
            get { return clarityLevel; }
            private set { clarityLevel = value; }
        }

        public int StrengthBonus
        {
            get
            { return strengthBonus;
            }
            private set
            {
                strengthBonus = value + (int)this.ClarityLevel;
            }
        }

        public int AgilityBonus
        {
            get
            {
                return agilityBonus;
            }
            private set
            {
                agilityBonus = value + (int)this.ClarityLevel;
            }
        }

        public int VitalityBonus
        {
            get
            {
                return vitalityBonus;
            }
            private set
            {
                vitalityBonus = value + (int)this.ClarityLevel;
            }
        }
    }
}
