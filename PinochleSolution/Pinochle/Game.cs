using System;
using System.Collections.Generic;

namespace Pinochle
{ 
    public class Game
    {
        public List<Player> Players         { get; set; }
        public List<Round>  Rounds          { get; set; }
        public Round        CurrentRound    { get { return Rounds[Rounds.Count - 1]; } }

        public Game()
        {
        }

        public Game(List<Player> players)
        {
            Players = players;
            Rounds = new List<Round>();
        }

        public List<Card> GenerateDeck()
        {
            List<Card> result = new List<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Face face in Enum.GetValues(typeof(Face)))
                {
                    result.Add(new Card(suit, face));
                    result.Add(new Card(suit, face));
                }
            }
            result.Shuffle();
            return result;
        }
    }
}
