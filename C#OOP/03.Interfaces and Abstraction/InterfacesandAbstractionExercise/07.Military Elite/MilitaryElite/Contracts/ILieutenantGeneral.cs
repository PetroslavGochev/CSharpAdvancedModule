using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts
{
    public interface ILieutenantGeneral :IPrivate
    {
        IReadOnlyCollection<ISoldier> Privates { get; }
        public void AddPrivate(ISoldier @private);
    }
}
