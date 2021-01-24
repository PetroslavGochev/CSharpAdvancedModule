using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddCollection : Collect
    {
        public AddCollection()
            : base()
        {

        }
        public override int Add(string element)
        {
            this.Collection.Add(element);
            return this.Collection.Count - 1;
        }
    }
}
