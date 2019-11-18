using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06_FootballTeamGenerator
{
    public class Player
    {
        private const int STATS_COUNT = 5;

        private string name;
        private List<Stat> stats;

        public Player(string name)
        {
            this.Name = name;
            this.Stats = new List<Stat>();
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }

        public List<Stat> Stats
        {
            get { return stats; }
            set { stats = value; }
        }

        public int Rating
        {
            get
            {
                return (int)Math.Round(((decimal)this.Stats.Sum(s => s.Value)) / 5);
            }
        }

    }
}
