using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCardGame
{
    class Deck
    {
        private Random randomNumbers;
        public Queue<Card> deck;
        public int size { get; set; }

        public Deck()
        {
            randomNumbers = new Random();
            deck = new Queue<Card>();
            size = 0;
        }

        public Deck(Queue<Card> deck)
        {
            randomNumbers = new Random();
            this.deck = deck;
            size = deck.Count();
        }

        public Card Draw()
        {
            return deck.Count() > 0 ? deck.Dequeue() : null;
        }

        public void AddCard(Card card)
        {
            deck.Enqueue(card);
        }

        public IEnumerable<Card> DrawMany(int x)
        {
            return deck.Take(x);
        }

        public void Shuffle()
        {
            
            Card[] temp = deck.ToArray();
            
            for (int first = 0; first < temp.Count(); first++)
            {
                int second = randomNumbers.Next(temp.Count());

                Card tempCard = temp[first];
                temp[first] = temp[second];
                temp[second] = tempCard;
            }

            deck.Clear();

            for (int i = 0; i < temp.Count(); i++)
            {
                deck.Enqueue(temp[i]);
            }
            
        }

        public int Count()
        {
            return deck.Count();
        }

        public void Clear()
        {
            deck.Clear();
        }

        public void PrintDeck()
        {
            Card[] temp = deck.ToArray();
            for (int i = 0; i < deck.Count(); i++)
            {
                Console.WriteLine(temp[i].ToString());
            }
        }

        public void ShuffleTogether(Deck deckToAdd)
        {
            while (deckToAdd.Count() > 0)
                this.AddCard(deckToAdd.Draw());

            this.Shuffle();
        }

        public void Generate52CardDeck()
        {
            deck.Clear();
            Queue<Card> newDeck = new Queue<Card>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    Card insertCard = new Card((Card.Suit)i, (Card.Face)j);
                    newDeck.Enqueue(insertCard);
                }
            }
            deck = newDeck;
        }

        public void Generate4CardDeck()
        {
            deck.Clear();
            Queue<Card> newDeck = new Queue<Card>();
            for (int i = 0; i < 4; i++)
            {
                Card insertCard = new Card((Card.Suit)i, Card.Face.Ace);
                newDeck.Enqueue(insertCard);
            }
            deck = newDeck;
        }

        // there has to be a better way to do this
        /// <summary>
        /// Adds an array of cards to the top of the deck
        /// </summary>
        /// <param name="cards"></param>
        public void AddToTop(Card[] cards)
        {
            deck.Reverse();
            for (int i = 0; i < cards.Count(); i++) { 
                this.AddCard(cards[i]);
            }
            deck.Reverse();
        }

    }
}
