using CounterStrike.Models.Guns.Contracts;
using System.Linq;

namespace CounterStrike.Repositories.Models
{
    public class GunRepository : Repository<IGun>
    {
        public GunRepository()
            :base()
        {

        }
        public override IGun FindByName(string name)
        {
            return this.Models.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
