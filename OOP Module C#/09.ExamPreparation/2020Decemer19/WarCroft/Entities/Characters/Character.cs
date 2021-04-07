using System;
using WarCroft.Constants;
using WarCroft.Entities.Inventory.Models;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;

        // TODO: Implement the rest of the class.

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
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
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                this.name = value;
            }
        }

        public double BaseHealth { get; protected set; }

        public double Health { get;  set; }

        public double BaseArmor { get; protected set; }

        public double Armor { get; private set; }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; private set; }

        public bool IsAlive => this.Health > 0;

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();
            if (this.Armor > 0)
            {
                if (this.Armor >= hitPoints)
                {
                    this.Armor -= hitPoints;
                    hitPoints = 0;
                }
                else
                {
                    hitPoints -= this.Armor;
                    this.Armor = 0;
                }
            }
            this.Health -= hitPoints;
            if(this.Health < 0)
            {
                this.Health = 0;
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();
            item.AffectCharacter(this);
        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}