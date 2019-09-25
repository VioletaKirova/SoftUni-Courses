namespace _07_InfernoInfinity.Modules.Weapons
{
    using Contracts;
    using Enums;
    using System.Linq;

    public abstract class Weapon : IWeapon
    {
        private string name;
        private Rarity rarityLevel;
        private int minDamage;
        private int maxDamage;
        private int sockets;
        private IGem[] gems;

        protected Weapon(string name, Rarity rarityLevel, int minDamage, int maxDamage, int sockets)
        {
            this.Name = name;
            this.RarityLevel = rarityLevel;
            this.MinDamage = minDamage;
            this.MaxDamage = maxDamage;
            this.Sockets = sockets;
            this.Gems = new IGem[this.Sockets];
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public Rarity RarityLevel
        {
            get { return rarityLevel; }
            private set { rarityLevel = value; }
        }

        public int MinDamage
        {
            get { return minDamage; }
            private set { minDamage = value; }
        }

        public int MaxDamage
        {
            get { return maxDamage; }
            private set { maxDamage = value; }
        }

        public int Sockets
        {
            get { return sockets; }
            private set { sockets = value; }
        }

        public IGem[] Gems
        {
            get { return gems; }
            private set { gems = value; }
        }

        public void AddGem(int socketIndex, IGem gemToAdd)
        {
            if (socketIndex < 0 || socketIndex > this.Sockets - 1)
            {
                return;
            }

            this.Gems[socketIndex] = gemToAdd;
        }

        public void RemoveGem(int socketIndex)
        {
            if (socketIndex < 0 || socketIndex > this.Sockets - 1)
            {
                return;
            }

            this.Gems[socketIndex] = null;
        }

        public override string ToString()
        {
            var strenght = this.Gems.Where(x => x != null).Sum(x => x.StrengthBonus);
            var agility = this.Gems.Where(x => x != null).Sum(x => x.AgilityBonus);
            var vitality = this.Gems.Where(x => x != null).Sum(x => x.VitalityBonus);

            this.MinDamage = (this.MinDamage * ((int)this.RarityLevel)) + strenght * 2 + agility;
            this.MaxDamage = (this.MaxDamage * ((int)this.RarityLevel)) + strenght * 3 + agility * 4;

            return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{strenght} Strength, +{agility} Agility, +{vitality} Vitality";
        }
    }
}
