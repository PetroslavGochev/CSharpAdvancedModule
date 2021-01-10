using System.Collections.Generic;

namespace MilitaryElite.Contacts
{
    public interface IEngineer:ISpecialisedSoldier
    {
        public IReadOnlyCollection<IRepair> Repairs { get;}
        public void AddRepairs(IRepair repair);
    }
}
