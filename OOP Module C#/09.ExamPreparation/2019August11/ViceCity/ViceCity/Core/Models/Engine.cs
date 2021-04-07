using System;
using System.Linq;
using ViceCity.Core.Contracts;
using ViceCity.IO.Contracts;
using ViceCity.IO.Models;

namespace ViceCity.Core.Models
{
    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
            
        }
        public void Run()
        {

            string inputArgs;
            string message = null;
            while ((inputArgs = this.reader.ReadLine()) != "Exit")
            {
                string[] data = inputArgs.Split().ToArray();
                string command = data[0];
                try
                {
                    if (command == "AddPlayer")
                    {
                        message = this.controller.AddPlayer(data[1]);
                    }
                    else if (command == "AddGun")
                    {
                        message = this.controller.AddGun(data[1], data[2]);
                    }
                    else if (command == "AddGunToPlayer")
                    {
                        message = this.controller.AddGunToPlayer(data[1]);
                    }
                    else if (command == "Fight")
                    {
                        message = this.controller.Fight();
                        
                    }

                }
                catch (Exception ae)
                {
                    message = ae.Message;
                }
                finally
                {
                    this.writer.WriteLine(message);
                }
            }
        }
    }
}
