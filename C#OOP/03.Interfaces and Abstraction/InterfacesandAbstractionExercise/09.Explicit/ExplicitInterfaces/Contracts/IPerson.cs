using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces.Contracts
{
    public interface IPerson
    {
        public int Age { get; }
        public string Name { get; }
        public string GetName();
    }
}
