namespace CounterStrike.Models.Guns.Models
{
    public class Pistol : Gun
    {
        public Pistol(string name, int bulletsCount) 
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if(this.BulletsCount == 0)
            {
                return 0;
            }
            this.BulletsCount -= 1;
            return 1;
        }
    }
}
