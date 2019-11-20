using System;
using System.Collections.Generic;
using System.Text;

namespace _07_FoodShortage.Contracts
{
    public interface IBuyer
    {
        int Food { get; }

        void BuyFood();
    }
}
