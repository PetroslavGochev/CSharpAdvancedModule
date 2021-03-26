namespace ViceCity.Models.Guns.Models
{
    public class Rifle : Gun
    {
        private const int BULLETS_PER_BARREL = 50;
        private const int TOTAL_BULLETS = 500;
        private const int RIFFLE_SHOOT_COUNT = 5;
        public Rifle(string name) 
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
                this.BulletsPerBarrel -= RIFFLE_SHOOT_COUNT;
                return RIFFLE_SHOOT_COUNT;
            }
            return 0;
        }
    }
}
