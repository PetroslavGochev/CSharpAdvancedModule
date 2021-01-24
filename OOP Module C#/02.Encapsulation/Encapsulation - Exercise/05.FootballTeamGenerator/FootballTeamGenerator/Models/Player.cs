using System;
using System.Collections.Generic;
using System.Text;
using FootballTeamGenerator.Common;

namespace FootballTeamGenerator.Models
{
    public class Player
    {
        private string name;
        private Stats stats;
        public Player(string name,Stats stats)
        {
            this.Name = name;
            this.stats = stats;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Validator.InvalidName);
                }
                this.name = value;
            }
        }
        public Stats Stats { get; set; }
        public double Skills => this.stats.Average();

    }
}
