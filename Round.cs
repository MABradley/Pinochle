using System;

namespace Pinochle
{
    public enum Phase
    {
        Bidding,
        Meld,
        Trick
    }

    public class Round
    {
        public int    Bid           { get; set; }
        public Phase  Phase         { get; set; }
        public Player HighestBidder { get; set; }

        public Round()
        {
        }
    }

}