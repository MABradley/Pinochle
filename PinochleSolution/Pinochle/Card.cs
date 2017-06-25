using System;

namespace Pinochle
{
    public enum Suit
    {
        Spades,
        Hearts,
        Clubs,
        Diamonds
    }

    public enum Face
    {
        Ace = 15,
        Ten = 14,
        King = 13,
        Queen = 12,
        Jack = 11,
        Nine = 9,
        Eight = 8,
        Seven = 7,
        Six = 6,
        Five = 5,
        Four = 4,
        Three = 3,
        Two = 2
    };

    public class Card
    {
        public Suit Suit  { get; set; }
        public Face Face  { get; set; }

        public Card()
        {
        }

        public override string ToString() { return Enum.GetName(typeof(Face), Face) + " of " + Enum.GetName(typeof(Suit), Suit); }
    }
}