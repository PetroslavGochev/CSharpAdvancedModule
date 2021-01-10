using System.Collections.Generic;

namespace MilitaryElite.Contacts
{
    public interface ILieutenantGeneral : IPrivate
    {
        public IReadOnlyCollection<ISoldier> Privates { get; }
        public void AddPrivates(ISoldier privates);
    }
}
