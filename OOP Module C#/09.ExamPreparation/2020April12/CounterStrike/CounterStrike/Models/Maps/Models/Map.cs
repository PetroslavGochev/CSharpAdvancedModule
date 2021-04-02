using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Models.Players.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public string Start(ICollection<IPlayer> players)
        {
            SectionPlayers(players);
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                PlayingGame(this.terrorist, this.counterTerrorist);
                PlayingGame(this.counterTerrorist, this.terrorist);
                if (!AnyAlive(this.counterTerrorist))
                {
                    sb.Append($"Terrorist wins!");
                    break;
                }
                else if (!AnyAlive(this.terrorist))
                {
                    sb.Append($"CounterTerrorist wins!");
                    break;
                }
            }
            return sb.ToString().TrimEnd();
        }

        private bool AnyAlive(ICollection<IPlayer> team)
        {
            return team.Any(x => x.IsAlive);
        }
        private void PlayingGame(ICollection<IPlayer> attackTeam, ICollection<IPlayer> defendTeam)
        {
            foreach (var player in attackTeam)
            {
                foreach (var defendPlayer in defendTeam)
                {
                    defendPlayer.TakeDamage(player.Gun.Fire());
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
