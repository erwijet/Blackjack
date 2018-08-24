using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace Blackjack
{
    public enum Suit
    {
        Heart = 0,
        Spades = 1,
        Diamond = 2,
        Club = 3
    }

    public class Deck
    {
        public IEnumerable<Card> cards { get; set; }

        public Deck(IEnumerable<Card> cards)
        {
            this.cards = cards;
        }

        public void SetupDeck(DirectoryInfo imagePath)
        {
            Bitmap[] images;
            if (imagePath.Exists)
            {
                images = new Bitmap[imagePath.GetFiles().Length];
                imagePath.GetFiles().CopyTo(images, 0);

            }
        }

        void InsertCard(Card c) => (this.cards as List<Card>).Add(c); // Add new card into the deck

        public Card this[int index]
        {
            get { return (this.cards as List<Card>)[index]; }
            set { (this.cards as List<Card>)[index] = value; }
        }
    }

    public struct Card
    {
        public Suit suit { get; set; }
        public int rank { get; set; }
        public Bitmap image { get; set; }

        public Card(Suit suit, int rank, Bitmap bitmap)
        {
            this.suit = suit;
            this.rank = rank;
            this.image = bitmap;
        }
    }
}