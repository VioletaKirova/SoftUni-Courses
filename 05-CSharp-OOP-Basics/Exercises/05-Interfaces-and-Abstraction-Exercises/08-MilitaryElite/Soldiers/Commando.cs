using _08_MilitaryElite.Contracts;
using System.Collections.Generic;
using System.Text;

namespace _08_MilitaryElite.Soldiers
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, decimal salary, Corps corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            Missions = new List<Mission>();
        }

        public List<Mission> Missions { get; set; }
        public IEnumerable<object> Repairs { get; private set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}")
                  .AppendLine($"Corps: {this.Corps}")
                  .AppendLine("Missions:");

            foreach (var m in this.Missions)
            {
                output.AppendLine($"  {m.ToString()}");
            }

            return output.ToString().Trim();
        }

    }
}
