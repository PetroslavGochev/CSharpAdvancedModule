using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Cards.Contracts;
using System;

namespace PlayersAndMonsters.Models.Cards.Models
{
    public class Card : ICard
    {
        private string name;
        private int damagePoints;
        private int healthPoints;

        public Card(string name, int damagePoints, int healthPoints)
        {
            this.Name = name;
            this.DamagePoints = damagePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Card's name cannot be null or an empty string.");
                }
                this.name = value;
            }
        }

        public int DamagePoints
        {
            get
            {
                return this.damagePoints;
            }
            set
            {
                if(value < 0  )
                {
                    throw new ArgumentException("Card's damage points cannot be less than zero.");
                }
                this.damagePoints = value;
            }
        }

        public int HealthPoints
        {
            get
            {
                return this.healthPoints;
            }
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Card's HP cannot be less than zero.");
                }
                this.healthPoints = value;
            }
        }

        public override string ToString()
        {
            return string.Format(ConstantMessages.CardReportInfo, this.Name, this.DamagePoints);
        }
    }
}
