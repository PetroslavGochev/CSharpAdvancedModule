using MilitaryElite.Contacts;
using MilitaryElite.Enumerator;
using System;

namespace MilitaryElite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private Corps corps;
        public SpecialisedSoldier(string firstName, string lastName, int id, decimal salary,string corps) 
            : base(firstName, lastName, id, salary)
        {
            this.Corps = corps;
        }

        public string Corps
        {
            get
            {
                return this.corps.ToString();
            }
            set
            {
                Corps corps;
                if (!Enum.TryParse<Corps>(value, out corps))
                {
                    throw new ArgumentException();
                }
                this.corps = corps;
            }
        }
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Corps: {this.Corps}";
        }
    }
}
