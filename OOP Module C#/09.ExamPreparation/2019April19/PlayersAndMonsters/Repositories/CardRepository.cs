using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private List<ICard> cards;
        public CardRepository()
        {
            this.cards = new List<ICard>();
        }
        public int Count => this.Cards.Count;

        public IReadOnlyCollection<ICard> Cards => this.cards;

        public void Add(ICard card)
        {
            CardIsNull(card);
            if(this.Cards.Any(c => c.Name == card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }
            this.cards.Add(card);
        }

        public ICard Find(string name)
        {
            return this.cards.Where(card => card.Name == name).FirstOrDefault();
        }

        public bool Remove(ICard card)
        {
            CardIsNull(card);
            return this.cards.Remove(card);
        }

        private void CardIsNull(ICard card)
        {
            if(card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }
        }
    }
}
