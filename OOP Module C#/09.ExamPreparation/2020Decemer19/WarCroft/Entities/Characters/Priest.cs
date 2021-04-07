using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory.Models;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const double BASE_HEALTH = 50;
        private const double BASE_ARMOR = 25;
        private const double ABILITY_POINTS = 40;

        public Priest(string name)
            : base(name, BASE_HEALTH, BASE_ARMOR, ABILITY_POINTS, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            character.TakeDamage(0);
            if (this.IsAlive && character.IsAlive)
            {
                character.Health += this.AbilityPoints;
            }
        }
    }

}
