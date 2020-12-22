using MilitaryElite.Contracts;
using MilitaryElite.Core.Contracts;
using MilitaryElite.Enumerations;
using MilitaryElite.Exceptions;
using MilitaryElite.IO.Contracts;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICollection<ISoldier> soldiers;
        private Engine()
        {
            this.soldiers = new List<ISoldier>();
        }
        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = this.reader.ReadLine()) != "End")
            {
                ISoldier soldier = null;
                string[] data = input.Split(" ",
                    StringSplitOptions.RemoveEmptyEntries);
                string type = data[0];
                int id = int.Parse(data[1]);
                string firstName = data[2];
                string lastName = data[3];
                decimal salary = 0;
                if (type != "Spy")
                {
                    salary = decimal.Parse(data[4]);
                }
                if (type == "Private")
                {
                    soldier = new Private(id, firstName, lastName, salary);
                }
                else if (type == "LieutenantGeneral")
                {
                    ILieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);
                    foreach (var item in data.Skip(5))
                    {
                        ISoldier privateToAdd = this.soldiers.First(x => x.Id == int.Parse(item));
                        general.AddPrivate(privateToAdd);
                    }
                    soldier = general;
                }
                else if (type == "Engineer")
                {
                    string crops = data[5];
                    soldier = new Engineer(id, firstName, lastName, salary, crops);
                    try
                    {
                        IEngineer engineer = new Engineer(id, firstName, lastName, salary, crops);
                        string[] repairsData = data
                            .Skip(6)
                            .ToArray();
                        for (int i = 0; i < repairsData.Length; i += 2)
                        {
                            string partName = repairsData[i];
                            int hoursWorked = int.Parse(repairsData[i + 1]);
                            IRepair repair = new Repair(partName, hoursWorked);
                            engineer.AddReair(repair);
                        }
                        soldier = engineer;
                    }
                    catch (InvalidCorpsExceptions ex)
                    {
                        continue;
                    }
                }
                else if (type == "Commando")
                {
                    string crops = data[5];
                    soldier = new Commando(id, firstName, lastName, salary, crops);
                    try
                    {
                        ICommando commando = new Commando(id, firstName, lastName, salary, crops);
                        string[] missionsData = data
                            .Skip(6)
                            .ToArray();
                        for (int i = 0; i < missionsData.Length; i += 2)
                        {
                            try
                            {
                                string codeName = missionsData[i];
                                string state = missionsData[i + 1];
                                IMission mission = new Mission(codeName, state);
                                commando.AddMission(mission);
                            }
                            catch (InvalidStateExceptions ex)
                            {
                                continue;
                            }
                        }
                        soldier = commando;
                    }
                    catch (InvalidCorpsExceptions ex)
                    {
                        continue;
                    }
                }
                else if (type == "Spy")
                {
                    int codeNumber = int.Parse(data[5]);
                    soldier = new Spy(id, firstName, lastName, codeNumber);
                }
                if(soldier != null)
                {
                    this.soldiers.Add(soldier);
                }
            }
            foreach (var soldier in this.soldiers)
            {
                this.writer.WriteLine(soldier.ToString());
            }
        }
    }
}
