namespace WarCroft.Entities.Inventory.Models
{
    public class Satchel : Bag
    {
        private const int CAPACITY = 20;
        public Satchel() 
            : base(CAPACITY)
        {
        }
    }
}
