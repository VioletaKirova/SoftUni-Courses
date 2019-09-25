namespace TheTankGame.Entities.Parts
{
    using Contracts;

    public class ShellPart : BasePart, IDefenseModifyingPart
    {
        public ShellPart(string model, double weight, decimal price, int defenseModifier) 
            : base(model, weight, price)
        {
            this.DefenseModifier = defenseModifier;
        }

        public int DefenseModifier { get; private set; }

        //TODO Check ToString method
        public override string ToString()
        {
            return base.ToString() + $"+{this.DefenseModifier} Defense";
        }
    }
}