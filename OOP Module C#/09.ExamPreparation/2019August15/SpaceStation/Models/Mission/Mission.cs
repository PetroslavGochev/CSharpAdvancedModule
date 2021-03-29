using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Planets;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        private IList<string> item;
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                if (!astronaut.CanBreath)
                {
                    continue;
                }
                foreach (var item in planet.Items)
                {
                    astronaut.Breath();
                    if (astronaut.CanBreath)
                    {
                        astronaut.Bag.Items.Add(item);
                        planet.Items.Remove(item);
                    }
                }

            }
            
        }
    }
}
