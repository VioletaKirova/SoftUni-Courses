﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _05_MordorsCruelPlan.Foods
{
    public class Lembas : Food
    {
        private const int happiness = 3;

        public Lembas() :
            base(happiness)
        {
        }
    }
}
