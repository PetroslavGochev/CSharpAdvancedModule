namespace ViceCity.Models.Guns.Models
{
    public class Rifle : Gun
    {
        private const int BULLETS_PER_BARREL = 50;
        private const int TOTAL_BULLETS = 500;
        public Rifle(string name) 
            : base(name, BULLETS_PER_BARREL, TOTAL_BULLETS)
        {
        }
    }
}
