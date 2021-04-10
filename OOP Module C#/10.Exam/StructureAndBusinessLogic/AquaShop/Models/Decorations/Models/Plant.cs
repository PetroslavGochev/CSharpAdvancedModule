namespace AquaShop.Models.Decorations.Models
{
    public class Plant : Decoration
    {
        private const int PLANT_COMFORT = 5;
        private const decimal PLANT_PRICE = 10;

        public Plant()
            : base(PLANT_COMFORT, PLANT_PRICE)
        {

        }
    }
}
