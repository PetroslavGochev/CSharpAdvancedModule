using SantaWorkshop.Core.Contracts;
using SantaWorkshop.IO;
using SantaWorkshop.IO.Contracts;
using System;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Core.Models
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
                string[] dataArgs = input.Split().ToArray();
                string command = dataArgs[0];
                try
                {
                    if (command == "Report")
                    {
                        sb.Append(this.controller.Report());
                        continue;
                    }
                    string nameOrType = dataArgs[1];
                    if (command == "AddDwarf")
                    {
                        string dwarfName = dataArgs[2];
                        sb.Append(this.controller.AddDwarf(nameOrType, dwarfName));
                    }
                    else if (command == "AddPresent")
                    {
                        int energyRequired = int.Parse(dataArgs[2]);
                        sb.Append(this.controller.AddPresent(nameOrType, energyRequired));
                    }
                    else if (command == "AddInstrumentToDwarf")
                    {
                        int power = int.Parse(dataArgs[2]);
                        sb.Append(this.controller.AddInstrumentToDwarf(nameOrType, power));
                    }
                    else if (command == "CraftPresent")
                    {
                        sb.Append(this.controller.CraftPresent(nameOrType));
                    }
                }
                catch (ArgumentException ae)
                {
                    sb.Append(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    sb.Append(ioe.Message);
                }
                finally
                {
                    this.writer.WriteLine(sb.ToString());
                    this.writer.WriteLine("-------");
                }
            }
        }
    }
}
