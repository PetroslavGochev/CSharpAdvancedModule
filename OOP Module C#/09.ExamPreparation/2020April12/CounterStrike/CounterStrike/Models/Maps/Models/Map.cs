using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Models.Players.Models;
using System.Collections.Generic;
using System.Linq;

namespace CounterStrike.Models.Maps.Models
{
    public class Map : IMap
    {
        private List<IPlayer> terrorist;
        private List<IPlayer> counterTerrorist;

        public Map()
        {
            this.terrorist = new List<IPlayer>();
            this.counterTerrorist = new List<IPlayer>();
        }
        public void Start(ICollection<IPlayer> players)
        {
            SectionPlayers(players);
            PlayingGame(this.terrorist,this.counterTerrorist);
            PlayingGame(this.counterTerrorist,this.terrorist);
        }

        private void PlayingGame(ICollection<IPlayer> attackTeam, ICollection<IPlayer> defendTeam)
        {
            foreach (var player in attackTeam)
            {
                if (!player.IsAlive)
                {
                    continue;
                }
                int damage = player.Gun.Fire();
                IPlayer defend = defendTeam.FirstOrDefault();
                if (defend != null && defend.IsAlive)
                {
                    defend.TakeDamage(damage);
                }
            }
        }

        private void SectionPlayers(ICollection<IPlayer> players)
        {
            foreach (var player in players)
            {
                if (player.GetType().Name == "Terrorist")
                {
                    this.terrorist.Add(player);
                }
                else if (player.GetType().Name == "CounterTerrorist")
                {
                    this.counterTerrorist.Add(player);
                }
            }
        }
    }
}
