using System;
using System.Collections.Generic;
using System.Text;

namespace _05_MordorsCruelPlan.Moods
{
    public abstract class Mood
    {
        public Mood()
        {
            this.State = "Mood";
        }

        public virtual string State { get; private set; }
    }
}
