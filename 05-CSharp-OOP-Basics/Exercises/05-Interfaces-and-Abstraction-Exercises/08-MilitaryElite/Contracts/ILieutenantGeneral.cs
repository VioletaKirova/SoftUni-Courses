using _08_MilitaryElite.Soldiers;
using System.Collections.Generic;

namespace _08_MilitaryElite.Contracts
{
    public interface ILieutenantGeneral
    {
        List<Private> Privates { get; set; }
    }
}
