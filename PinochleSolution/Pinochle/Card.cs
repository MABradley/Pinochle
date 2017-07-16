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
        Nine = 9
    };

    public class Card
    {
        public Suit Suit  { get; set; }
        public Face Face  { get; set; }

        public Card()
        {
        }

        public Card(Suit suit, Face face)
        {
            Suit = suit;
            Face = face;
        }

        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Card p = obj as Card;
            if ((System.Object)p == null)
            {
                return false;
            }
            return (Face == p.Face) && (Suit == p.Suit);
        }

        public override string ToString() { return Enum.GetName(typeof(Face), Face) + " of " + Enum.GetName(typeof(Suit), Suit); }
    }
}