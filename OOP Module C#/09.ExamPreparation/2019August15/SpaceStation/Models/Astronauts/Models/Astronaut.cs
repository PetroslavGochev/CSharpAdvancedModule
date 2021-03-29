using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using System;
using System.Text;

namespace SpaceStation.Models.Astronauts.Models
{
    public abstract class Astronaut : IAstronaut
    {
        private readonly IBag bag;
        private string name;
        private double oxygen;

        private Astronaut()
        {
            this.bag = new Bag();
        }
        protected Astronaut(string name, double oxygen)
            :this()
        {
            this.Name = name;
            this.Oxygen = oxygen;
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
                    throw new ArgumentNullException("Astronaut name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public double Oxygen
        {
            get
            {
                return this.oxygen;
            }
            protected set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Cannot create Astronaut with negative oxygen!");
                }
                this.oxygen = value;
            }
        }

        public bool CanBreath => this.Oxygen > 0;

        public IBag Bag => this.bag;

        public virtual void Breath()
        {
            IfOxygenIsNull(10);
        }

        protected void IfOxygenIsNull(int oxygen)
        {
            if(this.Oxygen < oxygen)
            {
                this.Oxygen = 0;
            }
            else
            {
                this.Oxygen -= oxygen;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Oxygen: {this.Oxygen}");
            sb.AppendLine($"Bag items: {this.Bag.ToString()}");
            return sb.ToString().TrimEnd();
        }
    }
}
