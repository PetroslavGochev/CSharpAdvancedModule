using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Models
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                if(value == null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }
                this.pilot = value;
            }
        }
        
        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; }

        public void Attack(IMachine target)
        {
            if(target== null)
            {
                throw new NullReferenceException("Target cannot be null");
            }
            double power = this.AttackPoints - this.DefensePoints;
            if(target.HealthPoints < power)
            {
                target.HealthPoints = 0;
            }
            else
            {
                target.HealthPoints -= power;
            }
            this.Targets.Add(target.Name);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Health: {this.HealthPoints}");
            sb.AppendLine($" *Attack: {this.AttackPoints}");
            sb.AppendLine($" *Defense: {this.DefensePoints}");
            sb.Append($" *Targets: ");
            if(this.Targets.Count == 0)
            {
                sb.AppendLine($"None");
            }
            for (int i = 0; i < this.Targets.Count; i++)
            {
                if(i == this.Targets.Count - 1)
                {
                    sb.AppendLine($"{this.Targets[i]}");
                }
                else
                {
                    sb.Append($"{this.Targets[i]},");
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}


