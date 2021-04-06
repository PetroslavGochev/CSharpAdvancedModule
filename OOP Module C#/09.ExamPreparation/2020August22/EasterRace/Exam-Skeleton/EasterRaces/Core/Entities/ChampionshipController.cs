using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private IRepository<IRace> races;
        private IRepository<IDriver> drivers;
        private IRepository<ICar> cars;

        public ChampionshipController()
        {
            this.races = new RaceRepository();
            this.drivers = new DriverRepository();
            this.cars = new CarRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            ICar car = this.cars.GetByName(carModel);
            IDriver driver = this.drivers.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }
            else if(car == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }
            else
            {
                driver.AddCar(car);
                return $"Driver {driver.Name} received car {car.Model}.";
            }
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = this.races.GetByName(raceName);
            IDriver driver = this.drivers.GetByName(driverName);

            if(race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            else if(driver == null)
            {
                throw new InvalidOperationException($"Driver { driverName } could not be found.");
            }
            else
            {
                race.AddDriver(driver);
                return $"Driver {driver.Name} added in {race.Name} race.";
            }

        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if(this.cars.GetByName(model) != null)
            {
                throw new ArgumentException($"Car {model} is already created.");
            }
            ICar car = null;
            if(type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }
            this.cars.Add(car);
            return $"{type}Car {model} is created.";
        }

        public string CreateDriver(string driverName)
        {

            if (this.drivers.GetByName(driverName) != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }
            IDriver driver = new Driver(driverName);
            this.drivers.Add(driver);
            return $"Driver { driver.Name} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            if(this.races.GetByName(name) != null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }

            IRace race = new Race(name, laps);
            this.races.Add(race);
            return $"Race {race.Name} is created.";
        }

        public string StartRace(string raceName)
        {
            IRace race = this.races.GetByName(raceName);

            if(race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            else if(race.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {race.Name} cannot start with less than 3 participants.");
            }
            StringBuilder sb = new StringBuilder();
                    IDriver[] winners = race.Drivers
                                                .OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps))
                                                .Take(3)
                                                .ToArray();

            for (int i = 1; i <= 3; i++)
            {
                if(i == 1)
                {
                    sb.AppendLine($"Driver {winners[i - 1].Name} wins {race.Name} race.");
                    winners[i - 1].WinRace();
                }
                else if(i == 2)
                {
                    sb.AppendLine($"Driver {winners[i - 1].Name} is second in {race.Name} race.");
                }
                else
                {
                    sb.Append($"Driver {winners[i - 1].Name} is third in {race.Name} race.");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
