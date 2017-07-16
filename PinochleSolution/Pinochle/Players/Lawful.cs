using System;

namespace Pinochle
{
    //Player class that obeys the rules
    public class Lawful : Player
    {
        public Lawful()
        {
        }

        public Lawful(string name, bool isEvil) : base(name, isEvil)
        {
        }

        public override int? MakeBid(Round round)
        {
            if (round.Bid is null)
            {
                return 10;//Minimum bid.
            }
            return null;//Pass, wouldn't want to risk it!
        }

        public override Suit ChooseTrump(Round round)
        {
            return Suit.Spades;//They look like shovels, how can you go wrong.
        }
    }
}
