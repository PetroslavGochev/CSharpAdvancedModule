using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using System;
using System.Collections.Generic;

namespace SantaWorkshop.Models.Dwarfs.Models
{
    public abstract class Dwarf : IDwarf
    {
        protected int ENERGY = 10;
        private string name;
        private int energy;
        private List<IInstrument> instruments;

        protected Dwarf(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.instruments = new List<IInstrument>();
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
                    throw new ArgumentException("Dwarf name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int Energy
        {
            get
            {
                return this.energy;
            }
            protected set
            {
                if(value < 0)
                {
                    value = 0;
                }
                this.energy = value;
            }
        }

        public ICollection<IInstrument> Instruments
            => this.instruments;

        public void AddInstrument(IInstrument instrument)
        {
            this.instruments.Add(instrument);
        }

        public abstract void Work();
        
    }
}
