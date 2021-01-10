using System.Collections.Generic;

namespace MilitaryElite.Contacts
{
    public interface ICommando : ISpecialisedSoldier
    {
        public IReadOnlyCollection<IMission> Missions { get;}
        public void AddMissions(IMission missions);
    }
}
