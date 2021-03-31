using MortalEngines.Core.Contracts;
using MortalEngines.Entities.Contracts;
using MortalEngines.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MortalEngines.Core.Models
{
    public class MachinesManager : IMachinesManager
    {
        private List<IPilot> pilots;
        private List<IMachine> machines;
        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine attackMachine = this.machines.Where(x => x.Name == attackingMachineName).FirstOrDefault();
            IMachine deffendMachine = this.machines.Where(x => x.Name == defendingMachineName).FirstOrDefault();
            if(attackingMachineName == null)
            {
                return $"Machine {attackingMachineName} could not be found";
            }
            else if(defendingMachineName == null)
            {
                return $"Machine {defendingMachineName} could not be found";
            }
            else if(attackMachine.HealthPoints == 0)
            {
                return $"Dead machine {attackingMachineName} cannot attack or be attacked";
            }
            else if (deffendMachine.HealthPoints == 0)
            {
                return $"Dead machine {defendingMachineName} cannot attack or be attacked";
            }
            else
            {
                attackMachine.Attack(deffendMachine);
                return $"Machine {defendingMachineName} was attacked by machine {attackingMachineName} " +
                    $"- current health: {deffendMachine.HealthPoints:f2}";
            }

        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            IPilot pilot = this.pilots.Where(x => x.Name == selectedPilotName).FirstOrDefault();
            IMachine machine = this.machines.Where(x => x.Name == selectedMachineName).FirstOrDefault();

            if(pilot == null)
            {
                return $"Pilot {selectedPilotName} could not be found";
            }
            else if (machine == null)
            {
                return $"Machine {selectedMachineName} could not be found";
            }
            else if(machine.Pilot != null)
            {
                return $"Machine {selectedMachineName} is already occupied";
            }
            else
            {
                pilot.AddMachine(machine);
                machine.Pilot = pilot;
                return $"Pilot {pilot.Name} engaged machine {machine.Name}";
            }
        }

        public string HirePilot(string name)
        {
            StringBuilder sb = new StringBuilder();
            if(this.pilots.Any(x=>x.Name == name))
            {
                sb.AppendLine($"Pilot {name} is hired already");
            }
            else
            {
                this.pilots.Add(new Pilot(name));
                sb.AppendLine($"Pilot {name} hired");
            }
            return sb.ToString().TrimEnd();
        }

        public string MachineReport(string machineName)
        {
            IMachine machine = this.machines
                .Where(x => x.Name == machineName)
                .FirstOrDefault();
            return machine.ToString();
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if(this.machines.Any(x=>x.Name == name))
            {
                return $"Machine {name} is manufactured already";
            }
            IFighter fighter = new Fighter(name, attackPoints, defensePoints);
            fighter.ToggleAggressiveMode();
            this.machines.Add(fighter);
            return $"Fighter {fighter.Name} manufactured - attack: {fighter.AttackPoints:f2}; defense: {fighter.DefensePoints:f2}; aggressive: ON";
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if(this.machines.Any(x=>x.Name == name))
            {
                return $"Machine {name} is manufactured already";
            }
            Tank machine = new Tank(name, attackPoints, defensePoints);
            machine.ToggleDefenseMode();
            this.machines.Add(machine);
            return $"Tank {machine.Name} manufactured - attack: {machine.AttackPoints:f2}; defense: {machine.DefensePoints:f2}";
        }

        public string PilotReport(string pilotReporting)
        {
            IPilot pilot = this.pilots
                .Where(x => x.Name == pilotReporting)
                .FirstOrDefault();
            return pilot.Report();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            if(!this.machines.Any(x=>x.Name == fighterName))
            {
                return $"Machine {fighterName} could not be found";
            }
            IMachine fighter = this.machines
                .Where(x => x.Name == fighterName)
                .FirstOrDefault();

            Fighter fighter1 = (Fighter)fighter;
            fighter1.ToggleAggressiveMode();
            return $"Fighter {fighterName} toggled aggressive mode";
        }

        public string ToggleTankDefenseMode(string tankName)
        {
           if(!this.machines.Any(x=>x.Name == tankName))
            {
                return $"Machine {tankName} could not be found";
            }
            IMachine machine = this.machines
                 .Where(X => X.Name == tankName)
                 .FirstOrDefault();
            Tank machineTank = (Tank)machine;
            machineTank.ToggleDefenseMode();
            return $"Tank {machine.Name} toggled defense mode";
        }
    }
}
