using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCardGame
{
    class PlayerSpace
    {

        public Deck discardPile;
        public Deck playerDeck;
        public List<Card> cardsOnTable;

        public PlayerSpace()
        {
            discardPile = new Deck();
            playerDeck = new Deck();
            cardsOnTable = new List<Card>();
        }

        public void MoveCardToDiscard(Card card)
        {
            discardPile.AddCard(card);
            cardsOnTable.Remove(card);
        }

    }
}
