using _05_MordorsCruelPlan.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_MordorsCruelPlan.Factories
{
    public class FoodFactory
    {
        public Food CreateFood(string type)
        {
            switch (type)
            {
                case "cram":
                    return new Cram();
                case "lembas":
                    return new Lembas();
                case "apple":
                    return new Apple();
                case "melon":
                    return new Melon();
                case "honeycake":
                    return new HoneyCake();
                case "mushrooms":
                    return new Mushrooms();
                default:
                    return new Junk();
            }
        }
    }
}
