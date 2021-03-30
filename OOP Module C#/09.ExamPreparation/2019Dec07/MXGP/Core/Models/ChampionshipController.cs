using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Motorcycles.Models;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Races.Models;
using MXGP.Models.Riders.Contracts;
using MXGP.Models.Riders.Models;
using MXGP.Repositories.Contracts;
using MXGP.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Core.Models
{
    class ChampionshipController : IChampionshipController
    {
        private IRepository<IRider> riders;
        private IRepository<IRace> races;
        private IRepository<IMotorcycle> motorcycles;

        public ChampionshipController()
        {
            this.riders = new RiderRepository();
            this.races = new RaceRepository();
            this.motorcycles = new MotorcycleRepository();
        }
        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            IMotorcycle motorcycle = this.motorcycles.GetByName(motorcycleModel);
            IRider rider = this.riders.GetByName(riderName);
            if(rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }
            else if(motorcycle == null)
            {
                throw new InvalidOperationException($"Motorcycle {motorcycleModel} could not be found.");
            }
            else
            {
                rider.AddMotorcycle(motorcycle);
                return $"Rider {rider.Name} received motorcycle {motorcycle.Model}.";
            }

        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            IRace race = this.races.GetByName(raceName);
            IRider rider = this.riders.GetByName(riderName);
            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            else if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }
            else
            {
                race.AddRider(rider);
                return $"Rider {rider.Name} added in {race.Name} race.";
            }
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            IMotorcycle motorcycle = null;
            if(type == "Power")
            {
                motorcycle = new PowerMotorcycle(model,horsePower);
            }
            else if(type == "Speed")
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
            }

            if (this.motorcycles.GetByName(model) != null)
            {
                throw new ArgumentException($"Motorcycle {motorcycle.Model} is already created.");
            }

            this.motorcycles.Add(motorcycle);
            return $"{motorcycle.GetType().Name} {motorcycle.Model} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);
            if (this.races.GetByName(race.Name) != null)
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }
            else
            {
                this.races.Add(race);
                return $"Race {race.Name} is created.";
            }
        }

        public string CreateRider(string riderName)
        {
            IRider rider = new Rider(riderName);
            if (this.riders.GetByName(riderName) != null)
            {
                throw new ArgumentException($"Rider {rider.Name} is already created.");
            }
            this.riders.Add(rider);
            return $"Rider {rider.Name} is created.";
        }

        public string StartRace(string raceName)
        {
            IRace race = this.races.GetByName(raceName);
            if(race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            else if(race.Riders.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }
            else
            {
                List<IRider> raceRiders = new List<IRider>();
                int lapsOfRace = race.Laps;
                foreach (var rider in race.Riders)
                {
                    raceRiders.Add(rider);
                }
                this.races.Remove(race);
                raceRiders = GetFirstThreeRiders(raceRiders, lapsOfRace);
                StringBuilder sb = new StringBuilder();
                for (int i = 1; i <= raceRiders.Count; i++)
                {
                    if(i == 1)
                    {
                        sb.AppendLine($"Rider {raceRiders[i-1].Name} wins {raceName} race.");
                    }
                    else if(i == 2)
                    {
                        sb.AppendLine($"Rider {raceRiders[i-1].Name} is second in {raceName} race.");
                    }
                    else if(i == 3)
                    {
                        sb.AppendLine($"Rider {raceRiders[i-1].Name} is third in {raceName} race.");
                    }
                }
                return sb.ToString().TrimEnd();
            }
        }

        private List<IRider> GetFirstThreeRiders(List<IRider> raceRiders,int lapsOfrace)
           =>  raceRiders
                .OrderByDescending(x => x.Motorcycle.CalculateRacePoints(lapsOfrace))
                .Take(3)
                .ToList();
    }
}
