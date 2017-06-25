﻿using System;
using System.Collections.Generic;

namespace Pinochle
{ 
    public class Game
    {
        public List<Player> Players { get; set; }
        public List<Round>  Rounds  { get; set; }

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