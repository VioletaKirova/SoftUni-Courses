using AnimalCentre.Models.Contracts;
using System;

namespace AnimalCentre.Models.Procedures
{
    public class Vaccinate : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }

            animal.Energy -= 8;

            animal.IsVaccinated = true;

            animal.ProcedureTime -= procedureTime;

            this.ProcedureHistory.Add(animal);
        }
    }
}
