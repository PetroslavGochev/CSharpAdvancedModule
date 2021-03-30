using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MXGP.Models.Races.Models
{
    public class Race : IRace
    {
        private string name;
        private int lap;
        private List<IRider> riders;
        public Race(string name,int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.riders = new List<IRider>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if(value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }
                this.name = value;
            }
        }

        public int Laps
        {
            get
            {
                return this.lap;
            }
            private set
            {
                if(value < 1)
                {
                    throw new ArgumentException("Laps cannot be less than 1.");
                }
                this.lap = value;
            }
        }

        public IReadOnlyCollection<IRider> Riders
            => this.riders.AsReadOnly();

        public void AddRider(IRider rider)
        {
            if(rider == null)
            {
                throw new ArgumentNullException("Rider cannot be null.");
            }
            else if (!rider.CanParticipate)
            {
                throw new ArgumentException($"Rider {rider.Name} could not participate in race.");
            }
            else if(this.riders.Any(r=>r.Name == rider.Name))
            {
                throw new ArgumentNullException($"Rider {rider.Name} is already added in {this.Name} race.");
            }
            else
            {
                this.riders.Add(rider);
            }
        }
    }
}
