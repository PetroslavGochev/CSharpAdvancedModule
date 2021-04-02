using CounterStrike.Models.Guns.Contracts;
using System;

namespace CounterStrike.Models.Guns.Models
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsCount;

        protected Gun(string name, int bulletsCount)
        {
            this.Name = name;
            this.BulletsCount = bulletsCount;
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
                    throw new ArgumentException("Gun cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int BulletsCount
        {
            get
            {
                return this.bulletsCount;
            }
            protected set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Bullets cannot be below 0.");
                }
                this.bulletsCount = value;
            }
        }

        public abstract int Fire();

        public override string ToString()
        {
            return this.Name;
        }
    }
}
