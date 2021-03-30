using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Riders.Contracts;
using System;

namespace MXGP.Models.Riders.Models
{
    public class Rider : IRider
    {
        private string name;

        public Rider(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }
                this.name = value;
            }
        }

        public IMotorcycle Motorcycle { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate
            => this.Motorcycle != null;

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if(motorcycle == null)
            {
                throw new ArgumentNullException("Motorcycle cannot be null.");
            }
            this.Motorcycle = motorcycle;
        }

        public void WinRace()
        => this.NumberOfWins++;
    }
}
