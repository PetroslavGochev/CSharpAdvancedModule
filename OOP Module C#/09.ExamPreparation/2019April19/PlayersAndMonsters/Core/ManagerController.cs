namespace PlayersAndMonsters.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.BattleFields.Models;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Cards.Models;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Models.Players.Models;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private ICardRepository cardRepository;
        private IPlayerRepository playerRepository;
        public ManagerController(ICardRepository cardRepository, IPlayerRepository playerRepository)
        {
            this.cardRepository = cardRepository;
            this.playerRepository = playerRepository;
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player;
            ICardRepository cardRepository = new CardRepository();
            if(type == "Beginner")
            {
                player = new Beginner(cardRepository,username);
            }
            else if(type == "Advanced")
            {
                player = new Advanced(cardRepository, username);
            }

            return $"Successfully added player of type {type} with username: {username}";
        }

        public string AddCard(string type, string name)
        {
            ICard card;

            if(type == "MagicCard")
            {
                card = new MagicCard(name);
            }
            else if(type == "TrapCard")
            {
                card = new TrapCard(name);
            }
            return $"Successfully added card of type {type}Card with name: {name}";
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = this.playerRepository.Players.Where(p => p.Username == username).FirstOrDefault();
            ICard card = this.cardRepository.Cards.Where(c => c.Name == cardName).FirstOrDefault();
            player.CardRepository.Add(card);
            return $"Successfully added card: {cardName} to user: {username}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attackPlayer = this.playerRepository.Players.Where(p => p.Username == attackUser).FirstOrDefault();
            IPlayer deffendPlayer = this.playerRepository.Players.Where(p => p.Username == enemyUser).FirstOrDefault();
            IBattleField battleField = new BattleField();
            battleField.Fight(attackPlayer, deffendPlayer);
            return $"Attack user health {attackUser} - Enemy user health {enemyUser}";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var player in this.playerRepository.Players)
            {
                sb.AppendLine(player.ToString());
                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(card.ToString());
                }
                sb.AppendLine($"###");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
