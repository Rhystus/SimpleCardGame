using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCardGame
{
    class Card
    {

        public enum Suit { Diamond, Heart, Club, Spade };
        public enum Face { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King };

        public Face value { get; }
        public Suit suit { get; }

        public Card()
        {
            this.value = Face.Ace;
            this.suit = Suit.Spade;
        }

        public Card(Suit suit, Face value)
        {
            this.value = value;
            this.suit = suit;
        }

        public override string ToString()
        {
            return this.value + " of " + this.suit;
        }
    }
}
