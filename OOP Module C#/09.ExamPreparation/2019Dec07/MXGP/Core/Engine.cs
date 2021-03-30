using MXGP.Core.Contracts;
using MXGP.Core.Models;
using MXGP.IO;
using MXGP.IO.Contracts;
using System;
using System.Linq;
using System.Text;

namespace MXGP.Core
{
    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IChampionshipController championshipController;

        public Engine()
        {
            this.writer = new ConsoleWriter();
            this.reader = new ConsoleReader();
            this.championshipController = new ChampionshipController();
        }
        public void Run()
        {
            string input;
            while((input = this.reader.ReadLine()) != "End")
            {
                StringBuilder sb = new StringBuilder();
                string[] dataArgs = input.Split().ToArray();
                string command = dataArgs[0];
                string name = dataArgs[1];
                try
                {
                    if (command == "CreateRider")
                    {
                        sb.Append(this.championshipController.CreateRider(name));
                    }
                    else if (command == "CreateMotorcycle")
                    {
                        string model = dataArgs[2];
                        int horsePower = int.Parse(dataArgs[3]);
                        sb.Append(this.championshipController.CreateMotorcycle(name, model, horsePower));
                    }
                    else if (command == "AddMotorcycleToRider")
                    {
                        string model = dataArgs[2];
                        sb.Append(this.championshipController.AddMotorcycleToRider(name, model));
                    }
                    else if (command == "AddRiderToRace")
                    {
                        string riderName = dataArgs[2];
                        sb.Append(this.championshipController.AddRiderToRace(name, riderName));
                    }
                    else if (command == "CreateRace")
                    {
                        int laps = int.Parse(dataArgs[2]);
                        sb.Append(this.championshipController.CreateRace(name, laps));
                    }
                    else if (command == "StartRace")
                    {
                        sb.Append(this.championshipController.StartRace(name));
                    }
                }
                catch (Exception e)
                {
                    sb.Append(e.Message);
                }
                finally
                {
                    this.writer.WriteLine(sb.ToString());
                }
            }
        }
    }
}
