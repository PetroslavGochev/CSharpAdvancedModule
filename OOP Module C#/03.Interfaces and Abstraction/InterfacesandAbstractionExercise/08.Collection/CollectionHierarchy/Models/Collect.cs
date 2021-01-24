using CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public abstract class Collect : IAddCollection
    {
        private IList<string> collection;
        public Collect()
        {
            this.collection = new List<string>();
        }
        protected IList<string> Collection => this.collection;

        public abstract int Add(string element);
    }
}
