using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int POWER = 100;
        public Paladin(string name)
            : base(name)
        {
        }

        public override int Power => POWER;
        public override string ToString()
        {
            return $"{base.ToString()} + healed for {this.Power}";
        }
    }
}
