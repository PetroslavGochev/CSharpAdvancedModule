using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums.Models
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private List<IDecoration> decorations;
        private List<IFish> fish;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int Capacity { get; }

        public int Comfort
            => this.Decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations
            => this.decorations;

        public ICollection<IFish> Fish
            => this.fish;

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.Capacity == this.fish.Count)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }
            this.fish.Add(fish);
        }

        public void Feed()
        {
            foreach (var f in this.fish)
            {
                f.Eat();
            }
        }

        public string GetInfo()
            => this.ToString();

        public bool RemoveFish(IFish fish)
            => this.fish.Remove(fish);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} ({ this.GetType().Name}):");
            sb.Append($"Fish: ");
            if (this.fish.Count == 0)
            {
                sb.AppendLine($"none");
            }
            for (int i = 0; i < this.fish.Count; i++)
            {
                if(i == this.fish.Count - 1)
                {
                    sb.AppendLine($"{this.fish[i].Name}");
                    continue;
                }
                sb.Append($"{this.fish[i].Name}, ");
            }
            sb.AppendLine($"Decorations: {this.decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");
            return sb.ToString().TrimEnd();

        }
    }
}
