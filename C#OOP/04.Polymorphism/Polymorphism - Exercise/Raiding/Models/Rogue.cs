using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int POWER = 80;
        public Rogue(string name) 
            : base(name)
        {
        }

        public override int Power => POWER;
        public override string ToString()
        {
            return $"{base.ToString()} + hit for {this.Power} damage";
        }
    }
}
