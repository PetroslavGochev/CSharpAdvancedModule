using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Contracts
{
    public interface IAddRemoveCollection : IAddCollection
    {
        public string Remove();
    }
}
