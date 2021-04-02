using CounterStrike.Core.Contracts;
using CounterStrike.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Core.Models
{
    public class Engine : IEngine
    {
        private Writer writer;
        private Reader reader;
        private Controller controller;

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

                try
                {
                    if(command == "AddGun")
                    {
                        string type = dataArgs[1];
                        string name = dataArgs[2];
                        int bulletsCount = int.Parse(dataArgs[3]);
                        sb.Append(this.controller.AddGun(type, name, bulletsCount));
                    }
                    else if(command == "AddPlayer")
                    {
                        string type = dataArgs[1];
                        string username = dataArgs[2];
                        int health = int.Parse(dataArgs[3]);
                        int armor = int.Parse(dataArgs[4]);
                        string gunName = dataArgs[5];
                        sb.Append(this.controller.AddPlayer(type, username, health,armor,gunName));
                    }
                    else if (command == "StartGame")
                    {
                        sb.Append(this.controller.StartGame());
                    }
                    else if (command == "Report")
                    {
                        sb.Append(this.controller.Report());
                    }

                }
                catch (ArgumentException ae)
                {
                    sb.Append(ae.Message);
                }
                finally
                {
                    this.writer.WriteLine(sb.ToString());
                    this.writer.WriteLine("======================");
                }
            }
        }
    }
}

