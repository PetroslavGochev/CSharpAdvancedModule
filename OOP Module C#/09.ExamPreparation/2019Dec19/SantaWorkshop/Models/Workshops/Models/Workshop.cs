using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;

namespace SantaWorkshop.Models.Workshops.Models
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {

        }
        public void Craft(IPresent present, IDwarf dwarf)
        {

            foreach (var instrument in dwarf.Instruments)
            {
                if (dwarf.Energy == 0)
                {
                    break;
                }
                if (instrument.IsBroken())
                {
                    continue;
                }
                present.GetCrafted();
                dwarf.Work();
                if (present.IsDone())
                {
                    break;
                }
            }

        }

    }
}
