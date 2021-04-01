namespace SantaWorkshop.Models.Dwarfs.Models
{
    public class HappyDwarf : Dwarf
    {
        public HappyDwarf(string name) 
            : base(name, 100)
        {
        }

        public override void Work()
        {
            this.Energy -= this.ENERGY;
        }
    }
}
