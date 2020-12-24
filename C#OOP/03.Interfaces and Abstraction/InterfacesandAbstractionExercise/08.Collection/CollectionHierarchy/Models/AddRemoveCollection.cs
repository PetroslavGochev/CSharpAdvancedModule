using CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : AddCollection, IAddRemoveCollection
    {
        protected const int index = 0;
        public override int Add(string element)
        {
            this.Collection.Insert(index, element);
            return index;
        }
        public virtual string Remove()
        {
            string element = this.Collection[this.Collection.Count - 1];
            this.Collection.RemoveAt(this.Collection.Count - 1);
            return element;
        }
    }
}
