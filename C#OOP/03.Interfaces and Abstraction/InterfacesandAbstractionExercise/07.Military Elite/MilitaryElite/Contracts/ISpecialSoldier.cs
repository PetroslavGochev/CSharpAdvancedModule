using MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts
{
    public interface ISpecialSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
