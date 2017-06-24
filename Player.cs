using System;

namespace Pinochle
{
    public class Player
    {
        public string     Name { get; set; }
        public List<Card> Hand { get; set; }

        public Player()
        {
        }
    }
}