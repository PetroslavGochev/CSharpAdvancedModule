using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Guns.Models;
using CounterStrike.Models.Maps.Models;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Models.Players.Models;
using CounterStrike.Repositories.Models;
using System;
using System.Linq;
using System.Text;

namespace CounterStrike.Core.Models
{
    public class Controller : IController
    {
        private GunRepository gun;
        private PlayerRepository player;
        private Map map;
        private StringBuilder sb;

        public Controller()
        {
            this.gun = new GunRepository();
            this.player = new PlayerRepository();
            this.map = new Map();
            this.sb = new StringBuilder();
        }
        public string AddGun(string type, string name, int bulletsCount)
        {
            sb.Clear();
            if(type != "Pistol" && type != "Rifle")
            {
                throw new ArgumentException("Invalid gun type.");
            }
            IGun gun = null;
            if(type == "Pistol")
            {
                gun = new Pistol(name, bulletsCount);
            }
            else if(type == "Rifle")
            {
                gun = new Rifle(name, bulletsCount);
            }
            this.gun.Add(gun);
            sb.Append($"Successfully added gun {gun.Name}.");
            return sb.ToString().TrimEnd();
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            sb.Clear();
            IGun gun = this.gun.FindByName(gunName);
            if(gun == null)
            {
                throw new ArgumentException("Gun cannot be found!");
            }
            else if(type != "Terrorist" && type != "CounterTerrorist")
            {
                throw new ArgumentException("Invalid player type!");
            }
            IPlayer player = null;
            if(type == "Terrorist")
            {
                player = new Terrorist(username,health,armor,gun);
            }
            else if (type == "CounterTerrorist")
            {
                player = new CounterTerrorist(username, health, armor, gun);
            }
            this.player.Add(player);
            sb.Append($"Successfully added player {player.Username}.");
            return sb.ToString().TrimEnd();
        }

        public string Report()
        {
            sb.Clear();
            foreach (var player in this.player.Models
                                            .OrderBy(x=>x.GetType().Name)
                                            .ThenBy(x=>x.Username))
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string StartGame()
        {
            sb.Clear();
            this.sb.Append(this.map.Start(this.player.Models.ToArray()));
            return sb.ToString().TrimEnd();
        }
    }
}
