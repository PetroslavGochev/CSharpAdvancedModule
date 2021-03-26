namespace ViceCity.Models.Guns.Models
{
    public class Pistol : Gun
    {
        private const int BULLETS_PER_BARREL = 10;
        private const int TOTAL_BULLETS = 100;
        private const int PISTOLE_SHOOT_COUNT = 1;
        public Pistol(string name) 
            : base(name, BULLETS_PER_BARREL, TOTAL_BULLETS)
        {
        }

        public override int Fire()
        {
            if (this.CanFire)
            {
                if (this.IsNeededReload())
                {
                    this.Reload(BULLETS_PER_BARREL);
                }
                this.BulletsPerBarrel -= PISTOLE_SHOOT_COUNT;
                return PISTOLE_SHOOT_COUNT;
            }
            return 0;
        }
    }
}
