using System;
using System.Collections.Generic;
using System.Text;

namespace _05_MordorsCruelPlan.Foods
{
    public class Apple : Food
    {
        private const int happiness = 1;

        public Apple() :
            base(happiness)
        {
        }
    }
}
