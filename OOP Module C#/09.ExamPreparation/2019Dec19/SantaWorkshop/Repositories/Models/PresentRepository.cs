using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SantaWorkshop.Repositories.Models
{
    public class PresentRepository : Repository<IPresent>
    {
        public PresentRepository()
            :base()
        {
        }

        public override IPresent FindByName(string name)
        => this.models.Where(x => x.Name == name).FirstOrDefault();
    }
}
