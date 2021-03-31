using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities.Models
{
    public class Tank : BaseMachine, ITank
    {
        public Tank(string name, double attackPoints, double defensePoints, double healthPoints) 
            : base(name, attackPoints, defensePoints, 100)
        {
            this.DefenseMode = true;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
                this.DefenseMode = false;
            }
            else
            {
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
                this.DefenseMode = true;
            }
        }

        public override string ToString()
        {
            string mode = this.DefenseMode ? "ON" : "OFF";
            return base.ToString() + $" *Defense: {mode}";
        }
    }
}
