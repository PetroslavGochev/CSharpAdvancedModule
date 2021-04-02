using CounterStrike.Models.Players.Contracts;
using System.Linq;

namespace CounterStrike.Repositories.Models
{
    public class PlayerRepository : Repository<IPlayer>
    {
        public PlayerRepository()
            :base()
        {

        }
        public override IPlayer FindByName(string name)
            => this.Models.Where(x => x.Username == name).FirstOrDefault();
    }
}
