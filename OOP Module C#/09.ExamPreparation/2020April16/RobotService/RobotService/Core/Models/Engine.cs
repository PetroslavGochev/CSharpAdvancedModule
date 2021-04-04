using RobotService.Core.Contracts;
using RobotService.IO;
using RobotService.IO.Contracts;
using System;
using System.Linq;
using System.Text;

namespace RobotService.Core.Models
{
    public class Engine : IEngine
    {
        private IController controller;
        private IWriter writer;
        private IReader reader;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }
        public void Run()
        {
            string input;
            while ((input = this.reader.ReadLine()) != "Exit")
            {
                StringBuilder sb = new StringBuilder();
                string[] dataArgs = input.Split().ToArray();
                string command = dataArgs[0];
                string nameOrType = dataArgs[1];
                try
                {
                    if(command == "Manufacture")
                    {
                        string name = dataArgs[2];
                        int energy = int.Parse(dataArgs[3]);
                        int happiness = int.Parse(dataArgs[4]);
                        int procedureTime = int.Parse(dataArgs[5]);          
                        sb.Append(this.controller.Manufacture(nameOrType,name,energy,happiness,procedureTime));
                    }
                    else if(command == "Chip")
                    {
                        int procedureTime = int.Parse(dataArgs[2]);
                        sb.Append(this.controller.Chip(nameOrType, procedureTime));
                    }
                    else if (command == "TechCheck")
                    {
                        int procedureTime = int.Parse(dataArgs[2]);
                        sb.Append(this.controller.TechCheck(nameOrType, procedureTime));
                    }
                    else if (command == "Rest")
                    {
                        int procedureTime = int.Parse(dataArgs[2]);
                        sb.Append(this.controller.Rest(nameOrType, procedureTime));
                    }
                    else if (command == "Work")
                    {
                        int procedureTime = int.Parse(dataArgs[2]);
                        sb.Append(this.controller.Work(nameOrType, procedureTime));
                    }
                    else if (command == "Charge")
                    {
                        int procedureTime = int.Parse(dataArgs[2]);
                        sb.Append(this.controller.Charge(nameOrType, procedureTime));
                    }
                    else if (command == "Polish")
                    {
                        int procedureTime = int.Parse(dataArgs[2]);
                        sb.Append(this.controller.Polish(nameOrType, procedureTime));
                    }
                    else if (command == "Sell")
                    {
                        string ownerName = dataArgs[2];
                        sb.Append(this.controller.Sell(nameOrType, ownerName));
                    }
                    else if (command == "History")
                    {
                        sb.Append(this.controller.History(nameOrType));
                    }
                }
                catch (Exception ex)
                {
                    sb.Append(ex.Message);
                }
                finally
                {
                    this.writer.WriteLine(sb.ToString());
                    this.writer.WriteLine("====================");
                }

            }
        }
    }
}
