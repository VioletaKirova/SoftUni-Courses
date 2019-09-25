namespace TheTankGame.Entities.Miscellaneous
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Parts.Contracts;

    public class VehicleAssembler : IAssembler
    {
        private readonly IList<IAttackModifyingPart> arsenalParts;
        private readonly IList<IDefenseModifyingPart> shellParts;
        private readonly IList<IHitPointsModifyingPart> enduranceParts;

        public VehicleAssembler()
        {
            this.arsenalParts = new List<IAttackModifyingPart>();
            this.shellParts = new List<IDefenseModifyingPart>();
            this.enduranceParts = new List<IHitPointsModifyingPart>();
        }

        public IReadOnlyCollection<IAttackModifyingPart> ArsenalParts
                                => this.arsenalParts.ToList().AsReadOnly();

        public IReadOnlyCollection<IDefenseModifyingPart> ShellParts
                                => this.shellParts.ToList().AsReadOnly();

        public IReadOnlyCollection<IHitPointsModifyingPart> EnduranceParts
                                => this.enduranceParts.ToList().AsReadOnly();

        public double TotalWeight
        {
            //=> this.ArsenalParts.Max(p => p.Weight) +
            //   this.ShellParts.Max(p => p.Weight) +
            //   this.EnduranceParts.Max(p => p.Weight);

            get
            {
                double totalWeight = 0;

                if (this.ArsenalParts.Any())
                {
                    totalWeight += this.ArsenalParts.Sum(p => p.Weight);
                }

                if (this.ShellParts.Any())
                {
                    totalWeight += this.ShellParts.Sum(p => p.Weight);
                }

                if (this.EnduranceParts.Any())
                {
                    totalWeight += this.EnduranceParts.Sum(p => p.Weight);
                }

                return totalWeight;
            }
        }

        public decimal TotalPrice
        {
            //=> this.ArsenalParts.Max(p => p.Price) +
            //   this.ShellParts.Max(p => p.Price) +
            //   this.EnduranceParts.Max(p => p.Price);

            get
            {
                decimal totalPrice = 0;

                if (this.ArsenalParts.Any())
                {
                    totalPrice += this.ArsenalParts.Sum(p => p.Price);
                }

                if (this.ShellParts.Any())
                {
                    totalPrice += this.ShellParts.Sum(p => p.Price);
                }

                if (this.EnduranceParts.Any())
                {
                    totalPrice += this.EnduranceParts.Sum(p => p.Price);
                }

                return totalPrice;
            }
        }

        public long TotalAttackModification
        {
            //=> this.ArsenalParts.Max(p => p.AttackModifier);
            get
            {
                long totalAttackModification = 0;

                if (this.ArsenalParts.Any())
                {
                    totalAttackModification = this.ArsenalParts.Sum(p => p.AttackModifier);
                }

                return totalAttackModification;
            }
        }

        public long TotalDefenseModification
        {
            //=> this.ShellParts.Max(p => p.DefenseModifier);
            get
            {
                long totalDefenseModification = 0;

                if (this.ShellParts.Any())
                {
                    totalDefenseModification = this.ShellParts.Sum(p => p.DefenseModifier);
                }

                return totalDefenseModification;
            }
        }

        public long TotalHitPointModification
        {
            //=> this.ShellParts.Max(p => p.DefenseModifier);
            get
            {
                long totalHitPointModification = 0;

                if (this.EnduranceParts.Any())
                {
                    totalHitPointModification = this.EnduranceParts.Sum(p => p.HitPointsModifier);
                }

                return totalHitPointModification;
            }
        }

        public void AddArsenalPart(IPart arsenalPart)
        {
            this.arsenalParts.Add((IAttackModifyingPart)arsenalPart);
        }

        public void AddShellPart(IPart shellPart)
        {
            this.shellParts.Add((IDefenseModifyingPart)shellPart);
        }

        public void AddEndurancePart(IPart endurancePart)
        {
            this.enduranceParts.Add((IHitPointsModifyingPart)endurancePart);
        }
    }
}