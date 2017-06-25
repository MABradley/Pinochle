using System;
using System.Collections.Generic;

namespace Pinochle
{
    public class Player
    {
        public  string     Name { get; set; }
        private List<Card> hand { get; set; }
        //Team Designator
        public  bool       IsEvil { get; set; }

        /// <summary>
        /// Asks the player to choose a bid
        /// if the player passes they will not receive another chance to bid
        /// </summary>
        /// <param name="round">The round the player is bidding on</param>
        /// <returns>The score the player beleives their team can make, or a null for pass</returns>
        public virtual int? MakeBid(Round round)
        {
            // Derived Class Will Implement
            throw new NotImplementedException();
        }

        public virtual Suit ChooseTrump(Round round)
        {
            // Derived Class WIll Implement
            throw new NotImplementedException();
        }

        public Player(string name, bool isEvil)
        {
            Name = name;
            IsEvil = isEvil;
        }

        public Player()
        {
        }

        public override string ToString() { return Name; }
    }
}