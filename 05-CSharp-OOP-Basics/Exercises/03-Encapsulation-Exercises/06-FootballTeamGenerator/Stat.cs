using System;
using System.Collections.Generic;
using System.Text;

namespace _06_FootballTeamGenerator
{
    public class Stat
    {
        private const int MIN_VALUE = 0;
        private const int MAX_VALUE = 100;

        private string name;
        private int value;

        public Stat(string name, int value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Value 
        {
            get { return value; }
            set
            {
                if (value < MIN_VALUE || value > MAX_VALUE)
                {
                    throw new ArgumentException($"{this.Name} should be between {MIN_VALUE} and {MAX_VALUE}.");
                }

                this.value = value;
            }
        }
    }
}
