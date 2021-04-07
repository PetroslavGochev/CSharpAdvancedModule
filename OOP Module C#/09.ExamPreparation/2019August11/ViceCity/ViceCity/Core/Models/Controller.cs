using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Guns.Models;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Neghbourhoods.Models;
using ViceCity.Models.Players.Contracts;
using ViceCity.Models.Players.Models;
using ViceCity.Repositories.Contracts;
using ViceCity.Repositories.Models;

namespace ViceCity.Core.Models
{
    public class Controller : IController
    {
        private ICollection<IPlayer> civilPlayer;
        private ICollection<IGun> guns;
        private IPlayer mainPlayer;
        private INeighbourhood neighbourhood;
        public Controller()
        {
            this.civilPlayer = new List<IPlayer>();
            this.guns = new List<IGun>();
            this.mainPlayer = new MainPlayer();
            this.neighbourhood = new Neighbourhood();
        }
        public string AddGun(string type, string name)
        {
            IGun gun;
            if(type == "Pistol")
            {
                gun = new Pistol(name);
            }
            else if(type == "Rifle")
            {
                gun = new Rifle(name);
            }
            else
            {
                return "Invalid gun type!";
            }
            this.guns.Add(gun);
            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            IGun gun;
            if(this.guns.Count == 0)
            {
                return "There are no guns in the queue!";
            }         
            gun = this.guns.First();
            if(name == "Vercetti")
            {

                this.mainPlayer.GunRepository.Add(gun);
                this.guns.Remove(gun);
                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }
            else if (!this.civilPlayer.Any(cp => cp.Name == name))
            {
                return $"Civil player with that name doesn't exists!";
            }
            else
            {
               IPlayer player =  this.civilPlayer.Where(x => x.Name == name).FirstOrDefault();
                player.GunRepository.Add(gun);
                this.guns.Remove(gun);
                return $"Successfully added {gun.Name} to the Civil Player: {player.Name}";
            }
        }

        public string AddPlayer(string name)
        {
            IPlayer civilPlayer = new CivilPlayer(name);
            this.civilPlayer.Add(civilPlayer);
            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            StringBuilder sb = new StringBuilder();
            int mainPlayerHealth = this.mainPlayer.LifePoints;
            int sumOfCivilPlayerHealth = CivilPlayerTotalHealth();
            int civilPLayerCountr = this.civilPlayer.Count;


            this.neighbourhood.Action(this.mainPlayer, this.civilPlayer);


            if(mainPlayer.LifePoints == mainPlayerHealth && sumOfCivilPlayerHealth == CivilPlayerTotalHealth())
            {
                return sb.AppendLine($"Everything is okay!")
                    .ToString()
                    .TrimEnd();
            }
            else
            {
                sb.AppendLine("A fight happened:");
                sb.AppendLine($"Tommy live points: {this.mainPlayer.LifePoints}!");
                sb.AppendLine($"Tommy has killed: {civilPLayerCountr - this.civilPlayer.Count} players!");
                sb.AppendLine($"Left Civil Players: {this.civilPlayer.Count}!");
                return sb.ToString().TrimEnd();
            }

        }
        private int CivilPlayerTotalHealth()
            => this.civilPlayer.Sum(c => c.LifePoints);

     
    }
}
