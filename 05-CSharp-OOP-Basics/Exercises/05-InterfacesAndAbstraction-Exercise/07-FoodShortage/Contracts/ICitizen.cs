using System;
using System.Collections.Generic;
using System.Text;

namespace _07_FoodShortage.Contracts
{
    public interface ICitizen
    {
        string Name { get; set; }
        string Age { get; set; }
        string Id { get; set; }
        string Birthday { get; set; }
    }
}
