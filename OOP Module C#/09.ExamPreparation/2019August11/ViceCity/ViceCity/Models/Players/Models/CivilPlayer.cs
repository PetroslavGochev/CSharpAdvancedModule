namespace ViceCity.Models.Players.Models
{
    public class CivilPlayer : Player
    {
        private const int LIFE_POINTS = 50;
        public CivilPlayer(string name)
            : base(name, LIFE_POINTS)
        {
        }
    }
}
