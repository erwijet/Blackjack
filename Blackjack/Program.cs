using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace Blackjack
{
    [Flags]
    enum CardValues
    {
        Two     = 0x02,
        Three   = 0x03,
        Four    = 0x04,
        Five    = 0x05,
        Six     = 0x06,
        Seven   = 0x07,
        Eight   = 0x08,
        Nine    = 0x09,
        Ten     = 0x0A,       // 10
        Jack    = 0x0A,       // 10
        Queen   = 0x0A,       // 10
        King    = 0x0A,       // 10
        Ace     = 0x0B        // 11
    }

    enum Faces
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    [Obsolete]
    [Flags]
    enum MagicNums
    {
        TRUE = 0x01,
        FALSE = 0x0
    }

    enum Suits
    {
        Hearts,
        Clubs,
        Diamonds,
        Spades
    }

    struct Card
    {
        public Faces face { get; set; }
        public Suits suit { get; set; }
        public override string ToString() => $@"{this.face} of {suit}";
    }

    class Deck
    {
        public List<Card> cards { get; set; }
        public int size { get => this.cards.Count; } 

        public Deck(int deckcount)
        {
            this.cards = new List<Card>();
            this.LoadDecks(deckcount);
            //this.Shuffle();
        }

        public void Shuffle()
        {
            int n = this.cards.Count;
            Random rng = new Random();
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = this.cards[k];
                this.cards[k] = this.cards[n];
                this.cards[n] = value;
            }
        }

        public Card DrawCard()
        {
            int count = this.cards.Count;
            Card drawnCard = this.cards[count - 1];
            this.cards.Remove(drawnCard);
            return drawnCard;
        }

        void LoadDecks(int deckcount)
        {
            for (int i = 0; i < deckcount; i++)
            {
                for (int suitindex = 0; suitindex < 4; suitindex++)
                {
                    for (int rankindex = 0; rankindex < 13; rankindex++)
                    {
                        this.cards.Add(new Card() { face = (Faces)rankindex, suit = (Suits)suitindex });
                    }
                }
            }
        }
    }

    class GameSettings
    {

    }

    class SideWagers
    {
        public bool LuckyLucky = false;
        public bool PerfectPairs = false;
        public bool RoyalMatch = false;
        public bool LuckyLadies = false;
        public bool InBet = false;
        public bool BustIt = false;
        public bool MatchTheDealer = false;
    }

    class Game
    {
        internal Game()
        {

        }
    }

    class Program
    {
        static void EndFile()
        {
#if DEBUG
            Write("Press any key to exit...");
            ReadKey(true);
#endif
        }

        static void Main(string[] args)
        {
            Deck deck = new Deck(2);
            foreach (Card c in deck.cards)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine($"{deck.size} cards");
            EndFile();
        }
    }
}
