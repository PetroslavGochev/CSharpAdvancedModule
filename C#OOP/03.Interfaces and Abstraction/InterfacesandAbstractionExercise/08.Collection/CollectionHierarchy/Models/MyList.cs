using CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class MyList : AddRemoveCollection, IMyList
    {
        public override string Remove()
        {
            string element = this.Collection[index];
            this.Collection.RemoveAt(index);
            return element;
        }
        public int Used() => this.Collection.Count;
       
    }
}
