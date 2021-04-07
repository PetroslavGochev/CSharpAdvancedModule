using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int WEIGHT = 5;
        public HealthPotion() 
            : base(WEIGHT)
        {
        }

        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                base.AffectCharacter(character);
            }
            character.Health += 20;
        }
    }
}
