using System;
using System.Collections.Generic;

namespace Pinochle
{
    public class Round
    {
        public int?             Bid             { get; set; }
        public Player           HighestBidder   { get; set; }
        public Suit?            Trump           { get; set; }
        private List<Player>    Players         { get; set; }
        
        public List<Card> Hand { get; set; } // This will contain a shallow copy of the player's hand from Hands
        private Dictionary<Player, List<Card>> Hands { get; set; }

        public Round()
        {
        }

        public Round(List<Player> players)
        {
            Players = players;
        }

        /// <summary>
        /// Call this before passing a player the round.
        /// </summary>
        /// <param name="p">The player to pass the round to</param>
        private void SetHand(Player p)
        {
            Hand = new List<Card>();
            foreach(var card in Hands[p])
            {
                var newCard = new Card { Face = card.Face, Suit = card.Suit };
                Hand.Add(newCard);
            }
        }

        public void PerformBidding()
        {
            //todo: allow players to see historical bids
            HashSet<Player> hasPassed = new HashSet<Player>();
            bool stillBidding = true;
            do
            {
                foreach (Player player in Players)
                {
                    if (hasPassed.Contains(player))
                    {
                        continue;
                    }
                    SetHand(player);
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
            SetHand(HighestBidder);
            Trump = HighestBidder.ChooseTrump(this);
        }

        public void TradeCards()
        {

        }
    }

}