using MortalEngines.Entities.Contracts;
using System;

namespace MortalEngines.Entities.Models
{
    public class Fighter : BaseMachine, IFighter
    {
        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, 200)
        {
            this.AggressiveMode = true;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode)
            {
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
            else
            {
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }
        }

        public override string ToString()
        {
            string mode = this.AggressiveMode ? "ON" : "OFF";
            return base.ToString() + Environment.NewLine + $" *Aggressive: {mode}";
        }
    }
}
