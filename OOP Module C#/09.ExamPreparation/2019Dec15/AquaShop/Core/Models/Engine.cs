using AquaShop.Core.Contracts;
using AquaShop.IO;
using AquaShop.IO.Contracts;
using System;
using System.Linq;
using System.Text;

namespace AquaShop.Core.Models
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
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
            while((input = this.reader.ReadLine()) != "Exit")
            {
                StringBuilder sb = new StringBuilder();
                string[] dataArgs = input.Split().ToArray();
                string command = dataArgs[0];
                try
                {
                    if(command == "Report")
                    {
                        sb.Append(this.controller.Report());
                        continue;
                    }
                    string nameOrType = dataArgs[1];
                    if(command == "AddAquarium")
                    {
                        string type = dataArgs[2];
                        sb.Append(this.controller.AddAquarium(nameOrType, type));
                    }
                    else if(command == "AddDecoration")
                    {
                        sb.Append(this.controller.AddDecoration(nameOrType));
                    }
                    else if (command == "InsertDecoration")
                    {
                        string type = dataArgs[2];
                        sb.Append(this.controller.InsertDecoration(nameOrType, type));
                    }
                    else if (command == "AddFish")
                    {
                        string fishType = dataArgs[2];
                        string fishName = dataArgs[3];
                        string fishSpieces = dataArgs[4];
                        decimal fishPrice = decimal.Parse(dataArgs[5]);
                        sb.Append(this.controller.AddFish(nameOrType, fishType, fishName, fishSpieces, fishPrice));
                    }
                    else if (command == "FeedFish")
                    {
                        sb.Append(this.controller.FeedFish(nameOrType));
                    }
                    else if (command == "CalculateValue")
                    {
                        sb.Append(this.controller.CalculateValue(nameOrType));
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
