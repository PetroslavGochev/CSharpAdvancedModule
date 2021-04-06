using EasterRaces.Models.Races.Contracts;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : Repository<IRace>
    {
        public RaceRepository()
            :base()
        {
        }

        public override IRace GetByName(string name)
            => this.Models.FirstOrDefault(x => x.Name == name);
    }
}
