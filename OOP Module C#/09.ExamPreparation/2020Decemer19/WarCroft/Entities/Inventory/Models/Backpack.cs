namespace WarCroft.Entities.Inventory.Models
{
    public class Backpack : Bag
    {
        private const int CAPACITY = 100;
        public Backpack() 
            : base(CAPACITY)
        {
            
        }
    }
}
