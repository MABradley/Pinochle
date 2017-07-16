using System;
using System.Collections.Generic;
using System.Linq;

namespace Pinochle
{
    public class Round
    {
        public Suit?            Trump           { get; set; }
        private List<Player>    Players         { get; set; }
        public Dictionary<int, Player>  Bids    { get; set; }
        
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
                    else if (Bids.Count > 0 && playerBid <= Bids.Keys.Max())
                    {
                        throw new Exception(player.Name + " has bid at or below the current bid.");
                    }
                    else if (playerBid < 10)
                    {
                        throw new Exception(player.Name + " has bid at or below the minimum bid of 10.");
                    }
                    Bids.Add(playerBid.Value, player);
                }
                if (hasPassed.Count > 2)
                {
                    stillBidding = false;
                }
            }
            while (stillBidding);
            SetHand(Bids[Bids.Keys.Max()]);
            Trump = Bids[Bids.Keys.Max()].ChooseTrump(this);
        }

        public void TradeCards()
        {

        }
    }

}