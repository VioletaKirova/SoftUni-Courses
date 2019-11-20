using _05_MordorsCruelPlan.Moods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_MordorsCruelPlan.Factories
{
    public class MoodFactory
    {
        public Mood CreateMood(string state)
        {
            switch (state)
            {
                case "angry":
                    return new Angry();
                case "sad":
                    return new Sad();
                case "happy":
                    return new Happy();
                case "javascript":
                    return new JavaScript();
                default:
                    throw new Exception("Invalid mood!");
            }
        }
    }
}
