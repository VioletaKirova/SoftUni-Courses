using _08_MilitaryElite.Soldiers;
using System.Collections.Generic;

namespace _08_MilitaryElite.Contracts
{
    public interface IEngineer
    {
        List<Repair> Repairs { get; set; }
    }
}
