using AnimalCentre.Models.Contracts;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        private List<IAnimal> procedureHistory;

        protected Procedure()
        {
            this.ProcedureHistory = new List<IAnimal>();
        }

        protected List<IAnimal> ProcedureHistory
        {
            get { return procedureHistory; }
            private set { procedureHistory = value; }
        }

        public string History()
        {
            StringBuilder result = new StringBuilder();

            string procedureType = this.GetType().Name;
            result.AppendLine(procedureType);

            foreach (var animal in this.ProcedureHistory)
            {
                result.AppendLine($"    Animal type: {animal.GetType().Name} - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
            }

            return result.ToString().Trim();
        }

        public abstract void DoService(IAnimal animal, int procedureTime);
    }
}
