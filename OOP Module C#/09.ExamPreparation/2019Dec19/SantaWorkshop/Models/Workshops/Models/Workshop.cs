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
                while (!instrument.IsBroken())
                {
                    if (dwarf.Energy == 0)
                    {
                        break;
                    }
                    present.GetCrafted();
                    dwarf.Work();
                    instrument.Use();
                    if (present.IsDone())
                    {
                        break;
                    }
                }
                if (present.IsDone())
                {
                    break;
                }
               
            }

        }

    }
}
