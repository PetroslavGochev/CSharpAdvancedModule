using SpaceStation.Core.Contracts;
using SpaceStation.IO;
using SpaceStation.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core.Models
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }
        public void Run()
        {
            string input;
            while((input = this.reader.ReadLine()) != "Exit")
            {
                StringBuilder sb = new StringBuilder();
                try
                {
                    string[] inputArgs = input
                    .Split()
                    .ToArray();
                    string command = inputArgs[0];
                    if (command == "Report")
                    {
                        sb.AppendLine(this.controller.Report());
                    }
                    else if (command == "AddAstronaut")
                    {
                        string type = inputArgs[1];
                        string name = inputArgs[2];
                        sb.AppendLine(this.controller.AddAstronaut(type, name));
                    }
                    else if (command == "AddPlanet")
                    {
                        string planetName = inputArgs[1];
                        List<string> planetParams = new List<string>();
                        for (int i = 2; i < inputArgs.Length; i++)
                        {
                            planetParams.Add(inputArgs[i]);
                        }
                        sb.AppendLine(this.controller.AddPlanet(planetName, planetParams.ToArray()));
                    }
                    else if (command == "RetireAstronaut")
                    {
                        string astronautName = inputArgs[1];
                        sb.AppendLine(this.controller.RetireAstronaut(astronautName));
                    }
                    else if (command == "ExplorePlanet")
                    {
                        string planetName = inputArgs[1];
                        sb.AppendLine(this.controller.ExplorePlanet(planetName));
                    }
                }
                catch (Exception e)
                {
                    sb.AppendLine(e.Message);
                }
                finally
                {
                    this.writer.WriteLine(sb.ToString());
                }
            }
        }
    }
}
