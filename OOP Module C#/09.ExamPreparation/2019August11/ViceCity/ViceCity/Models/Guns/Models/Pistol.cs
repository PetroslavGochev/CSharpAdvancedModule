namespace ViceCity.Models.Guns.Models
{
    public class Pistol : Gun
    {
        private const int BULLETS_PER_BARREL = 10;
        private const int TOTAL_BULLETS = 100;
        public Pistol(string name) 
            : base(name, BULLETS_PER_BARREL, TOTAL_BULLETS)
        {
        }
    }
}
