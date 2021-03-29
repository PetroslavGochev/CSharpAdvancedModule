using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Astronauts.Models;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Core.Models
{
    public class Controller : IController
    {
        private AstronautRepository astronautRepository;
        private PlanetRepository planetRepository;
        private Mission mission;
        private int explorePlanets;

        public Controller()
        {
            this.astronautRepository = new AstronautRepository();
            this.planetRepository = new PlanetRepository();
            this.mission = new Mission();
            this.explorePlanets = 0;
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }
            this.astronautRepository.Add(astronaut);
            return $"Successfully added {astronaut.GetType().Name}: {astronaut.Name}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }
            this.planetRepository.Add(planet);
            return $"Successfully added Planet: {planet.Name}!";
        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet planet = this.planetRepository.FindByName(planetName);
            List<IAstronaut> astronauts = new List<IAstronaut>();
            foreach (var astronaut in this.astronautRepository.Models)
            {
                if(astronaut.Oxygen >= 60)
                {
                    astronauts.Add(astronaut);
                }
            }
            if(astronauts.Count == 0)
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }
            this.mission.Explore(planet, astronauts);
            this.explorePlanets++;
            return $"Planet: {planet.Name} was explored! Exploration finished with {NumberOfDeathAstronauts(astronauts)} dead astronauts!";
        }

        private int NumberOfDeathAstronauts(List<IAstronaut> astronauts)
        {
            int count = 0;
            foreach (var astronaut in astronauts)
            {
                if (!astronaut.CanBreath)
                {
                    count++;
                }
            }
            return count;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.explorePlanets} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach (var astronaut in this.astronautRepository.Models)
            {
                sb.AppendLine(astronaut.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = this.astronautRepository.FindByName(astronautName);
            if (!this.astronautRepository.Remove(astronaut))
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }
            return $"Astronaut {astronaut.Name} was retired!";
        }
    }
}
