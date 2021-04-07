using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        private const int WEIGHT = 5;
        public FirePotion() 
            : base(WEIGHT)
        {
        }

        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                base.AffectCharacter(character);
            }

            character.Health -= 20;
        }
    }
}
