using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Aquariums.Models;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Decorations.Models;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Models.Fish.Models;
using AquaShop.Repositories.Contracts;
using AquaShop.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core.Models
{
    public class Controller : IController
    {
        private IRepository<IDecoration> decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {

            if (aquariumType != "FreshwaterAquarium" && aquariumType != "SaltwaterAquarium")
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }
            IAquarium aquarium = null;
            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            this.aquariums.Add(aquarium);
            return $"Successfully added { aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType != "Plant" && decorationType != "Ornament")
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }
            IDecoration decoration = null;
            if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            this.decorations.Add(decoration);
            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != "FreshwaterFish" && fishType != "SaltwaterFish")
            {
                throw new InvalidOperationException("Invalid fish type.");
            }
            IFish fish = null;
            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName,fishSpecies,price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            IAquarium aquarium = this.aquariums.Where(x => x.Name == aquariumName).FirstOrDefault();
            if (aquarium.GetType().Name.Contains("Fresh") && fish.GetType().Name.Contains("Fresh"))
            {
                aquarium.AddFish(fish);
            }
            else if(aquarium.GetType().Name.Contains("Salt") && fish.GetType().Name.Contains("Salt"))
            {
                aquarium.AddFish(fish);
            }
            else
            {
                return $"Water not suitable.";
            }

            return $"Successfully added {fish.GetType().Name} to {aquariumName}.";
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.Where(x => x.Name == aquariumName)
                .FirstOrDefault();
            decimal sumOfFish = aquarium.Fish.Sum(x => x.Price);
            decimal sumOfDecoration = aquarium.Decorations.Sum(x => x.Price);
            decimal result = sumOfFish + sumOfDecoration;
            return $"The value of Aquarium {aquarium.Name} is {result:f2}.";

        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.Where(x => x.Name == aquariumName).FirstOrDefault();
            foreach (var fish in aquarium.Fish)
            {
                fish.Eat();
            }
            return $"Fish fed: {aquarium.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = this.decorations.FindByType(decorationType);
            if (decoration == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }
            IAquarium aquarium = this.aquariums.Where(x => x.Name == aquariumName).FirstOrDefault();
            this.decorations.Remove(decoration);
            aquarium.AddDecoration(decoration);

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
