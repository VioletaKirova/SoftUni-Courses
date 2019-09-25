using _08_MilitaryElite.Soldiers;
using System.Collections.Generic;

namespace _08_MilitaryElite.Contracts
{
    internal interface ICommando
    {
        List<Mission> Missions { get; set; }
    }
}