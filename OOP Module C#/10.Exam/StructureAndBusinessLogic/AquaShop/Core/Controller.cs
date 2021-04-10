using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Aquariums.Models;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Decorations.Models;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Models.Fish.Models;
using AquaShop.Repositories.Contracts;
using AquaShop.Repositories.Models;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IDecoration> decorations;
        private readonly List<IAquarium> aquariums;
        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;
            if(aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if(aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            this.aquariums.Add(aquarium);
            return string.Format(OutputMessages.SuccessfullyAdded, aquarium.GetType().Name);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;
            if(decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if(decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
            this.decorations.Add(decoration);
            return string.Format(OutputMessages.SuccessfullyAdded, decoration.GetType().Name);

        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = null;
            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            if (fishType != nameof(FreshwaterFish) && fishType != nameof(SaltwaterFish))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }
            else
            {
                string currentAquariumType = aquarium.GetType().Name;

                if (fishType == "FreshwaterFish" && currentAquariumType == "FreshwaterAquarium")
                {
                    fish = new FreshwaterFish(fishName, fishSpecies, price);
                }
                else if (fishType == "SaltwaterFish" && currentAquariumType == "SaltwaterAquarium")
                {
                    fish = new SaltwaterFish(fishName, fishSpecies, price);
                }
                else
                {
                    return OutputMessages.UnsuitableWater;
                }
                aquarium.AddFish(fish);
                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            decimal sum = 0;
            foreach (var item in aquarium.Decorations)
            {
                sum += item.Price;
            }
            foreach (var item in aquarium.Fish)
            {
                sum += item.Price;
            }
            return string.Format(OutputMessages.AquariumValue, aquarium.Name, sum);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium.Feed();
            return String.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = this.decorations.FindByType(decorationType);
            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }
            else
            {
                aquarium.AddDecoration(decoration);
                decorations.Remove(decoration);
                return string.Format(OutputMessages.EntityAddedToAquarium, decoration.GetType().Name, aquarium.Name);
            }
        }

        public string Report()
        {

            StringBuilder sb = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
