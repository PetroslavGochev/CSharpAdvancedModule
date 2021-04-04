using RobotService.Core.Contracts;
using RobotService.Models.Garages.Models;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Procedures.Models;
using RobotService.Models.Robots.Contracts;
using RobotService.Models.Robots.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Core.Models
{
    public class Controller : IController
    {
        private Garage garage;
        private Procedure procedure;
        private IRobot robot;
        private List<Procedure> procedureList;

        public Controller()
        {
            this.garage = new Garage();
            this.procedureList = new List<Procedure>();
        }
        public string Charge(string robotName, int procedureTime)
        {
            string type = "Charge";
            if (!this.procedureList.Any(x=>x.GetType().Name == type))
            {
                this.procedure = new Charge();
                this.procedureList.Add(this.procedure);
            }
            else
            {
                this.procedure = GetProcedureFromCollection(type);
            }
            IfRobotDoesntExist(robotName);
            this.robot = GetRobotFromGarage(robotName);
            procedure.DoService(robot, procedureTime);
            this.procedure.Robots.Add(this.robot);
            return $"{this.robot.Name} had charge procedure";
        }

        private Procedure GetProcedureFromCollection(string type)
        {
            return this.procedureList.Where(x => x.GetType().Name == type).FirstOrDefault();
        }
        public string Chip(string robotName, int procedureTime)
        {
            string type = "Chip";
            if (!this.procedureList.Any(x => x.GetType().Name == type))
            {
                this.procedure = new Chip();
                this.procedureList.Add(this.procedure);
            }
            else
            {
                this.procedure = GetProcedureFromCollection(type);
            }
            IfRobotDoesntExist(robotName);
            this.robot = GetRobotFromGarage(robotName);
            procedure.DoService(robot, procedureTime);
            this.procedure.Robots.Add(this.robot);
            return $"{robot.Name} had chip procedure";
        }

        private IRobot GetRobotFromGarage(string robotName)
        {
            return this.garage.Robots
                .Where(x => x.Key == robotName)
                .Select(x => x.Value)
                .FirstOrDefault();
        }

        public string History(string procedureType)
        {
            if(procedureType == "Charge")
            {
                this.procedure = GetProcedureFromCollection(procedureType);
            }
            else if(procedureType == "Chip")
            {
                this.procedure = GetProcedureFromCollection(procedureType);
            }
            else if (procedureType == "Polish")
            {
                this.procedure = GetProcedureFromCollection(procedureType);
            }
            else if (procedureType == "Rest")
            {
                 this.procedure = GetProcedureFromCollection(procedureType);
            }
            else if (procedureType == "TechCheck")
            {
                this.procedure = GetProcedureFromCollection(procedureType);
            }
            else if (procedureType == "Work")
            {
                this.procedure = GetProcedureFromCollection(procedureType);

            }
            return this.procedure.History();

        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            
            if (robotType == "PetRobot")
            {
                this.robot = new PetRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "HouseholdRobot")
            {
                this.robot = new HouseholdRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "WalkerRobot")
            {
                this.robot = new WalkerRobot(name, energy, happiness, procedureTime);
            }
            else
            {
                throw new ArgumentException($"{robotType} type doesn't exist");
            }
            this.garage.Manufacture(this.robot);
            return $"Robot {robot.Name} registered successfully";
        }

        public string Polish(string robotName, int procedureTime)
        {
            string type = "Polish";
            if (!this.procedureList.Any(x => x.GetType().Name == type))
            {
                this.procedure = new Polish();
                this.procedureList.Add(this.procedure);
            }
            else
            {
                this.procedure = GetProcedureFromCollection(type);
            }
            IfRobotDoesntExist(robotName);
            this.robot = GetRobotFromGarage(robotName);
            procedure.DoService(robot, procedureTime);
            this.procedure.Robots.Add(this.robot);
            return $"{this.robot.Name} had polish procedure";
        }

        public string Rest(string robotName, int procedureTime)
        {
            string type = "Rest";
            if (!this.procedureList.Any(x => x.GetType().Name == type))
            {
                this.procedure = new Rest();
                this.procedureList.Add(this.procedure);
            }
            else
            {
                this.procedure = GetProcedureFromCollection(type);
            }
            IfRobotDoesntExist(robotName);
            this.robot = GetRobotFromGarage(robotName);
            procedure.DoService(robot, procedureTime);
            this.procedure.Robots.Add(this.robot);
            return $"{this.robot.Name} had rest procedure";
        }

        public string Sell(string robotName, string ownerName)
        {
            IfRobotDoesntExist(robotName);
            this.robot = GetRobotFromGarage(robotName);
            this.garage.Sell(robotName, ownerName);
            if (this.robot.IsChipped)
            {
                return $"{ownerName} bought robot with chip";
            }
            else
            {
                return $"{ownerName} bought robot without chip";
            }

        }

        public string TechCheck(string robotName, int procedureTime)
        {
            string type = "TechCheck";
            if (!this.procedureList.Any(x => x.GetType().Name == type))
            {
                this.procedure = new TechCheck();
                this.procedureList.Add(this.procedure);
            }
            else
            {
                this.procedure = GetProcedureFromCollection(type);
            }
            IfRobotDoesntExist(robotName);
            this.robot = GetRobotFromGarage(robotName);
            procedure.DoService(robot, procedureTime);
            this.procedure.Robots.Add(this.robot);
            return $"{this.robot.Name} had tech check procedure";
        }

        public string Work(string robotName, int procedureTime)
        {
            string type = "Work";
            if (!this.procedureList.Any(x => x.GetType().Name == type))
            {
                this.procedure = new Work();
                this.procedureList.Add(this.procedure);
            }
            else
            {
                this.procedure = GetProcedureFromCollection(type);
            }
            IfRobotDoesntExist(robotName);
            this.robot = GetRobotFromGarage(robotName);
            procedure.DoService(robot, procedureTime);
            this.procedure.Robots.Add(this.robot);
            return $"{this.robot.Name} was working for {procedureTime} hours";
        }

        private void IfRobotDoesntExist(string name)
        {
            if (!this.garage.Robots.ContainsKey(name))
            {
                throw new ArgumentException($"Robot {name} does not exist");
            }
        }
    }
}
