namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double CUBIC_CENTIMETERS = 5000;
        private const int MINIMUM_HP = 400;
        private const int MAXIMUM_HP = 600;
        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower, CUBIC_CENTIMETERS, MINIMUM_HP, MAXIMUM_HP)
        {
        }
    }
}
