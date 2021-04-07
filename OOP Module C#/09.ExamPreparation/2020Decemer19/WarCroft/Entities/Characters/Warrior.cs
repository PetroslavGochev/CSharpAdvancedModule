using System;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory.Models;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double BASE_HEALTH = 100;
        private const double BASE_ARMOR = 50;
        private const double ABILITY_POINTS = 40;


        public Warrior(string name)
            : base(name, BASE_HEALTH, BASE_ARMOR, ABILITY_POINTS, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            character.TakeDamage(0);
            if (this.IsAlive && character.IsAlive)
            {
                if(this.Name == character.Name)
                {
                    throw new InvalidOperationException("Cannot attack self!");
                }
                character.TakeDamage(this.AbilityPoints);
            }
        }
    }
}
