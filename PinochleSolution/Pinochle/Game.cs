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
    }
}
