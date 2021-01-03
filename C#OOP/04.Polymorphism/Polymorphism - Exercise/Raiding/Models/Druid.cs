using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int POWER = 80;
        public Druid(string name) 
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
