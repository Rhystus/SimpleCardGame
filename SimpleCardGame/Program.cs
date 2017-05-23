using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SimpleCardGame
{
    class Program
    {
        static void Main(string[] args)
        {

            Deck sessionDeck = new Deck();
            Deck discardPile = new Deck();

            Console.WriteLine("Hello!");

            #region Instructions
            Console.WriteLine("This is a simple program to test the card handling functionality.");
            Console.WriteLine("Commands are:");
            Console.WriteLine("1: Create 52-card Poker deck");
            Console.WriteLine("2: Shuffle deck");
            Console.WriteLine("3: Draw card from deck");
            Console.WriteLine("4: Shuffle discard into deck");
            Console.WriteLine("5: Print deck");
            Console.WriteLine("6: Clear deck");
            Console.WriteLine("7: Generate 4 card deck");
            Console.WriteLine("8: Shuffle discard with deck");
            Console.WriteLine("0: Close program");
            #endregion

            ConsoleKeyInfo currentKey;
            while (!(currentKey = Console.ReadKey()).Key.Equals(ConsoleKey.D0))
            {
                // Console.WriteLine(currentKey.Key.ToString());

                switch (currentKey.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("Generating poker deck...");
                        sessionDeck.Generate52CardDeck();
                        break;

                    case ConsoleKey.D2:
                        Console.WriteLine("Shuffling deck...");
                        sessionDeck.Shuffle();
                        break;

                    case ConsoleKey.D3:
                        Console.WriteLine("Drawing card...");
                        Card drawnCard = sessionDeck.Draw();
                        Console.WriteLine(drawnCard.ToString());
                        discardPile.AddCard(drawnCard);
                        break;

                    case ConsoleKey.D5:
                        Console.WriteLine("Printing deck...");
                        sessionDeck.PrintDeck();
                        break;

                    case ConsoleKey.D6:
                        Console.WriteLine("Clearing deck...");
                        sessionDeck.Clear();
                        break;

                    case ConsoleKey.D7:
                        Console.WriteLine("Generating 4 card deck...");
                        sessionDeck.Generate4CardDeck();
                        break;

                    case ConsoleKey.D8:
                        Console.WriteLine("Shuffling discard with deck...");
                        sessionDeck.ShuffleTogether(discardPile);
                        break;
                        
                    default:
                        Console.WriteLine("Key not supported.");
                        break;
                }
                Console.WriteLine("Done.");
            }
            Console.WriteLine("Exiting program.");
            Thread.Sleep(1000);
        }

    }
}
