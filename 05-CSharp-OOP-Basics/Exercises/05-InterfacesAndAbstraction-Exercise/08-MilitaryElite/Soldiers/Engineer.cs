using _08_MilitaryElite.Contracts;
using System.Collections.Generic;
using System.Text;

namespace _08_MilitaryElite.Soldiers
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, decimal salary, Corps corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            Repairs = new List<Repair>();
        }

        public List<Repair> Repairs { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}")
                  .AppendLine($"Corps: {this.Corps}")
                  .AppendLine("Repairs:");

            foreach (var r in this.Repairs)
            {
                output.AppendLine($"  {r.ToString()}");
            }

            return output.ToString().Trim();
        }
    }
}
