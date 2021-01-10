using MilitaryElite.Contacts;
using MilitaryElite.Core.Contracts;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite.Core
{
    public class Enginee : IEnginee
    {
        public void Run()
        {
            List<ISoldier> soldiers = new List<ISoldier>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                ISoldier soldier = null;
                string[] data = input.Split(" ",
                    StringSplitOptions.RemoveEmptyEntries);
                string type = data[0];
                int id = int.Parse(data[1]);
                string firstName = data[2];
                string lastName = data[3];
                if (type == "Private")
                {
                    decimal salary = decimal.Parse(data[4]);
                    soldier = new Private(firstName, lastName, id, salary);
                }
                else if (type == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(data[4]);
                    ILieutenantGeneral general = new LieutenantGeneral(firstName, lastName, id, salary);
                    foreach (var item in data.Skip(5))
                    {
                        ISoldier privateToAdd = soldiers.First(x => x.Id == int.Parse(item));
                        general.AddPrivates(privateToAdd);
                    }
                    soldier = general;
                }
                else if (type == "Engineer")
                {
                    decimal salary = decimal.Parse(data[4]);
                    string corps = data[5];
                    try
                    {
                        IEngineer engineer = new Engineer(firstName, lastName, id, salary, corps);
                        string[] repairsData = data
                            .Skip(6)
                            .ToArray();
                        for (int i = 0; i < repairsData.Length; i += 2)
                        {
                            string partName = repairsData[i];
                            int hoursWorked = int.Parse(repairsData[i + 1]);
                            IRepair repair = new Repair(partName, hoursWorked);
                            engineer.AddRepairs(repair);
                        }
                        soldier = engineer;
                    }
                    catch (ArgumentException)
                    {
                        continue;
                    }
                }
                else if (type == "Commando")
                {
                    decimal salary = decimal.Parse(data[4]);
                    string corps = data[5];
                    try
                    {
                        ICommando commando = new Commando(firstName, lastName, id, salary, corps);
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
                                commando.AddMissions(mission);
                            }
                            catch (ArgumentException)
                            {
                                continue;
                            }
                        }
                        soldier = commando;
                    }
                    catch (ArgumentException ex)
                    {
                        continue;
                    }
                }
                else if (type == "Spy")
                {
                    int codeNumber = int.Parse(data[4]);
                    soldier = new Spy(firstName, lastName, id, codeNumber);
                }
                if (soldier != null)
                {
                    soldiers.Add(soldier);
                }  
            }
            foreach (var item in soldiers)
            {
                Console.WriteLine(item);
            }
        }
    }
}