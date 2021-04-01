using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SantaWorkshop.Repositories.Models
{
    public class DwarfRepository : Repository<IDwarf>
    {
        public DwarfRepository()
            :base()
        {

        }

        public override IDwarf FindByName(string name)
        => this.models.Where(x => x.Name == name).FirstOrDefault();
    }
}
