using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts
{
    public interface IEngineer : ISpecialSoldier
    {
      IReadOnlyCollection<IRepair> Repair { get; }
        void AddReair(IRepair repair);
    }
}
