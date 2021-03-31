using MortalEngines.Core.Contracts;
using System;
using System.Linq;
using System.Text;

namespace MortalEngines.Core.Models
{
    public class Engine : IEngine
    {
        private IMachinesManager machinesManager;

        public Engine()
        {
            this.machinesManager = new MachinesManager();
        }
        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "Quit")
            {
                StringBuilder sb = new StringBuilder();
                string[] dataArgs = input.Split().ToArray();
                string command = dataArgs[0];
                string name = dataArgs[1];
                try
                {

                    if (command == "HirePilot")
                    {
                       sb.Append(this.machinesManager.HirePilot(name));
                    }
                    else if (command == "PilotReport")
                    {
                        sb.Append(this.machinesManager.PilotReport(name));
                    }
                    else if (command == "ManufactureTank")
                    {
                        double attack = double.Parse(dataArgs[2]);
                        double defense = double.Parse(dataArgs[3]);
                        sb.Append(this.machinesManager.ManufactureTank(name, attack, defense));
                    }
                    else if (command == "ManufactureFighter")
                    {
                        double attack = double.Parse(dataArgs[2]);
                        double defense = double.Parse(dataArgs[3]);
                        sb.Append(this.machinesManager.ManufactureFighter(name, attack, defense));

                    }
                    else if (command == "AggressiveMode")
                    {
                        sb.Append(this.machinesManager.ToggleFighterAggressiveMode(name));
                    }
                    else if (command == "MachineReport")
                    {
                        sb.Append(this.machinesManager.MachineReport(name));
                    }
                    else if (command == "DefenseMode")
                    {
                        sb.Append(this.machinesManager.ToggleTankDefenseMode(name));
                    }
                    else if (command == "Engage")
                    {
                        string machineName = dataArgs[2];
                        sb.Append(this.machinesManager.EngageMachine(name, machineName));
                    }
                    else if (command == "Attack")
                    {
                        string machineName = dataArgs[2];
                        sb.Append(this.machinesManager.AttackMachines(name, machineName));
                    }

                }
                catch (Exception e)
                {
                    sb.Append($"Error:" + e.Message);
                }
                finally
                {
                    Console.WriteLine(sb.ToString());
                }

            }
        }
    }
}
