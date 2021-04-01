using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Dwarfs.Models;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Instruments.Models;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Presents.Models;
using SantaWorkshop.Models.Workshops.Models;
using SantaWorkshop.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Core.Models
{
    public class Controller : IController
    {
        private DwarfRepository dwarfs;
        private PresentRepository presents;
        private Workshop workshop;

        public Controller()
        {
            this.dwarfs = new DwarfRepository();
            this.presents = new PresentRepository();
            this.workshop = new Workshop();
        }
        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf dwarf = null;
            if(dwarfType != "HappyDwarf" && dwarfType != "SleepyDwarf")
            {
                throw new InvalidOperationException("Invalid dwarf type.");
            }
            else if(dwarfType == "HappyDwarf")
            {
                dwarf = new HappyDwarf(dwarfName);
            }
            else if (dwarfType == "SleepyDwarf")
            {
                dwarf = new SleepyDwarf(dwarfName);
            }
            this.dwarfs.Add(dwarf);
            return $"Successfully added {dwarf.GetType().Name} named {dwarf.Name}.";
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            IDwarf dwarf = this.dwarfs.FindByName(dwarfName);
            if(dwarf == null)
            {
                throw new InvalidOperationException("The dwarf you want to add an instrument to doesn't exist!");
            }
            IInstrument instrument = new Instrument(power);
            dwarf.AddInstrument(instrument);
            return $"Successfully added instrument with power {instrument.Power} to dwarf {dwarf.Name}!";
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            IPresent present = new Present(presentName,energyRequired);
            this.presents.Add(present);
            return $"Successfully added Present: {present.Name}!";
        }

        public string CraftPresent(string presentName)
        {
            IPresent present = this.presents.FindByName(presentName);
            List<IDwarf> dwarfsReadyToCraft = this.dwarfs.Models
                .Where(x => x.Energy >= 50)
                .OrderByDescending(x => x.Energy)
                .ToList();
            StringBuilder sb = new StringBuilder();
            if (dwarfsReadyToCraft.Count == 0)
            {
                throw new InvalidOperationException("There is no dwarf ready to start crafting!");
            }
            foreach (var dwarf in dwarfsReadyToCraft)
            {
                this.workshop.Craft(present,dwarf);
                if (present.IsDone())
                {
                    break;
                }
            }
            sb.Append($"Present { present.Name} is ");
            if (present.IsDone())
            {
                sb.Append("done.");
            }
            else
            {
                sb.Append("not done.");
            }
            RemoveDrawfsFromCollection(dwarfsReadyToCraft);
            return sb.ToString().TrimEnd();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.presents.Models.Where(x => x.IsDone()).Count()} presents are done!");
            sb.AppendLine($"Dwarfs info:");
            foreach (var dwarf in this.dwarfs.Models)
            {
                sb.AppendLine(dwarf.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        private void RemoveDrawfsFromCollection(List<IDwarf> dwarfsAfterCraft)
        {
            foreach (var dwarf in dwarfsAfterCraft)
            {
                if(dwarf.Energy == 0)
                {
                    this.dwarfs.Remove(dwarf);
                }
            }
        }
    }
}
