using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FootballTeamGenerator.Common;

namespace FootballTeamGenerator.Models
{
    public class Team
    {
        private string teamName;
        private List<Player> players;
        private Team()
        {
            players = new List<Player>();
        }
        public Team(string teamName)
            : this()
        {
            this.TeamName = teamName;
        }
        private int NumberOfPlayers { get => this.players.Count;}
        public string TeamName
        {
            get => this.teamName;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Validator.InvalidName);
                }
                this.teamName = value;
            }
        }
        public int TeamRating => players.Count != 0 ? (int)Math.Round(this.players.Sum(x => x.Skills) / this.NumberOfPlayers): 0;
        public void Add(Player player) => players.Add(player);
        public void Remove(string playerName)
        {
            
            Player player = null;
            foreach (var item in this.players)
            {
                if(item.Name == playerName)
                {
                    player = item;
                }
            }
            if (player == null)
            {
                throw new ArgumentException(String.Format(Validator.PlayerNotExist,playerName,this.TeamName));
            }
            this.players.Remove(player);
        }
        public override string ToString()
        {
            return $"{this.TeamName} - {this.TeamRating}";
        }

    }
}
