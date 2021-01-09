using MilitaryElite.Contracts;
using MilitaryElite.Enumerations;
using MilitaryElite.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary,string corps) 
            : base(id, firstName, lastName, salary)
        {
            this.Corps = this.TryParseCorps(corps);
        }

        public Corps Corps { get; private set; }
        private Corps TryParseCorps(string stringCorps)
        {
            bool parse = Enum.TryParse<Corps>(stringCorps, out Corps corps);
            if (!parse)
            {
                throw new InvalidCorpsExceptions();
            }
            return corps;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{base.ToString()}");
            sb.AppendLine($"Corps: {this.Corps}");
            return sb.ToString().TrimEnd();
        }
    }
}
