namespace Bakery.Models.Drinks.Models
{
    public class Water : Drink
    {
        private const decimal PRICE = 1.50M;
        public Water(string name, int portion, string brand) 
            : base(name, portion, PRICE, brand)
        {
        }
    }
}
