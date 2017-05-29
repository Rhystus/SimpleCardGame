using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NLua;

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
            Console.WriteLine("9: Add an array of cards to the top of the deck");
            Console.WriteLine("A: Test the Lua integration");
            Console.WriteLine("0: Close program");
            #endregion

            ConsoleKeyInfo currentKey;
            while (!(currentKey = Console.ReadKey()).Key.Equals(ConsoleKey.D0))
            {
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

                    case ConsoleKey.D9:
                        Console.WriteLine("Adding cards to top of deck...");
                        // add cards to the top of the deck
                        break;

                    case ConsoleKey.A:
                        Console.WriteLine("Testing Lua integration...");
                        luaIntegration();
                        break;

                    default:
                        Console.WriteLine("Key not supported.");
                        break;
                }
                Console.WriteLine("Done.");
            }
            Console.WriteLine("Exiting program...");
            Thread.Sleep(1000);
        }

        private static void luaIntegration()
        {
            try
            {
                Lua lua = new Lua();
                lua.DoFile(".\\Lua\\example.lua");
                LuaFunction hello = lua["hello"] as LuaFunction;
                hello.Call();

                //call function that return string
                LuaFunction returnHello = lua["returnHello"] as LuaFunction;
                var funcHello = (String)returnHello.Call().First();
                Console.WriteLine("---call and return a string = " + funcHello);
                //or
                var funcHello1 = lua.DoString("return returnHello()");
                Console.WriteLine("---DoString and return a string = " + funcHello1.First().ToString());

                //call function that return sum two number
                var sumAandB = lua.DoString("return sumAandB(1,2)");
                Console.WriteLine("---return sum two numbers = " + sumAandB.First().ToString());

                //call function that return table                
                var objTable = lua.DoString("return getTable()"); //object[]
                Console.WriteLine("---return a table or a class");
                foreach (LuaTable lstObj in objTable)
                {
                    foreach (KeyValuePair<object, object> i in lstObj)
                    {
                        Console.WriteLine("{0} = {1}", i.Key.ToString(), i.Value.ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex + ".");
                Console.WriteLine(System.IO.Directory.GetCurrentDirectory().ToString());
            }
        }

    }
}
