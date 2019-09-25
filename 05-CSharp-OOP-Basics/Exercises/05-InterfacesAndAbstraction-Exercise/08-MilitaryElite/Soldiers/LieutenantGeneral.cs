using _08_MilitaryElite.Contracts;
using System.Collections.Generic;
using System.Text;

namespace _08_MilitaryElite.Soldiers
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
            Privates = new List<Private>();
        }

        public List<Private> Privates { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}")
                  .AppendLine("Privates:");

            foreach (var p in this.Privates)
            {
                output.AppendLine($"  {p.ToString()}");
            }

            return output.ToString().Trim();
        }
    }
}
