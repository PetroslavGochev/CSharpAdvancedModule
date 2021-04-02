using CounterStrike.Models.Guns.Contracts;

namespace CounterStrike.Models.Players.Models
{
    public class CounterTerrorist : Player
    {
        public CounterTerrorist(string username, int health, int armor, IGun gun) 
            : base(username, health, armor, gun)
        {
        }
    }
}
