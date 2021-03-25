using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Models.Players.Models;
using PlayersAndMonsters.Repositories;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            IPlayer player = null;
            ICardRepository cardRepository = new CardRepository();
            if (type == "Beginner")
            {
                player = new Beginner(cardRepository, username);
            }
            else if (type == "Advanced")
            {
                player = new Advanced(cardRepository, username);
            }
            return player;
        }
    }
}
