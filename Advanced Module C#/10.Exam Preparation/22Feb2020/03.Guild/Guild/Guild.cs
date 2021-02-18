using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private ICollection<Player> roster;

        private Guild()
        {
            this.roster = new List<Player>();
        }
        public Guild(string name, int capacity)
            : this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.roster.Count;

        public void AddPlayer(Player player)
        {
            if(this.Count < this.Capacity)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
            => this.roster
            .Remove(this.roster.Where(x => x.Name == name)
            .FirstOrDefault());

        public void PromotePlayer(string name)
        {
           var player = this.roster.Where(x => x.Name == name).FirstOrDefault();
            player.Rank = "Member";
        }
        public void DemotePlayer(string name)
        {
            var player = this.roster.Where(x => x.Name == name).FirstOrDefault();
            player.Rank = "Trial";
        }
        public Player[] KickPlayersByClass(string clas)
        {
            var players = this.roster.Where(x => x.Class == clas).ToArray();
            foreach (var p in players)
            {
                this.roster.Remove(p);
            }
            return players;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in this.roster)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
