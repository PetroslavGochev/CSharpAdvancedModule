namespace SantaWorkshop.Models.Dwarfs.Models
{
    public class SleepyDwarf : Dwarf
    {
        private const int ENERGY_SLEEPY = 5;
        public SleepyDwarf(string name) 
            : base(name, 50)
        {
        }

        public override void Work()
        {
            int sum = this.ENERGY + ENERGY_SLEEPY;
            this.Energy -= sum;
        }
    }
}
