using System;
using System.Collections.Generic;

namespace Pinochle
{
    public class Round
    {
        public int?   Bid           { get; set; }
        public Player HighestBidder { get; set; }
        public Suit?  Trump         { get; set; }

        public Round()
        {
        }

        public void PreformBidding(List<Player> players)
        {
            //todo: allow players to see historical bids
            HashSet<Player> hasPassed = new HashSet<Player>();
            bool stillBidding = true;
            do
            {
                foreach (Player player in players)
                {
                    if (hasPassed.Contains(player))
                    {
                        continue;
                    }
                    int? playerBid = player.MakeBid(this);
                    if (playerBid is null)
                    {
                        if (hasPassed.Count == 3)
                        {
                            throw new Exception(player.Name + " has passed when all other players have already passed.");
                        }
                        hasPassed.Add(player);
                        if (hasPassed.Count == 3)
                        {
                            break;
                        }
                    }
                    else if (Bid.HasValue && playerBid <= Bid)
                    {
                        throw new Exception(player.Name + " has bid at or below the current bid.");
                    }
                    else if (playerBid < 10)
                    {
                        throw new Exception(player.Name + " has bid at or below the minimum bid of 10.");
                    }
                    Bid = playerBid;
                    HighestBidder = player;
                }
                if (hasPassed.Count > 2)
                {
                    stillBidding = false;
                }
            }
            while (stillBidding);
            Trump = HighestBidder.ChooseTrump(this);
        }
    }

}