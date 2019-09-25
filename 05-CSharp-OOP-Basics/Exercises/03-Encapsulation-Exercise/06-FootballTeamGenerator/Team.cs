using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06_FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.Players = new List<Player>();
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

        public int Rating
        {
            get
            {
                return (int)Math.Round(this.Players.Average(p => p.Rating));
            }
        }

        public List<Player> Players
        {
            get { return players; }
            set { players = value; }
        }

        public override string ToString()
        {
            string output = "";

            if (this.Players.Any())
            {
                output = $"{this.Name} - {this.Rating}";
            }
            else
            {
                output = $"{this.Name} - 0";
            }

            return output;
        }
    }
}
