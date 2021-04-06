namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double CUBIC_CENTIMETERS = 3000;
        private const int MINIMUM_HP = 250;
        private const int MAXIMUM_HP = 450;
        public SportsCar(string model, int horsePower) 
            : base(model, horsePower, CUBIC_CENTIMETERS, MINIMUM_HP, MAXIMUM_HP)
        {
        }
    }
}
