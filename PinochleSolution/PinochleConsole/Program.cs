using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pinochle;

namespace PinochleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create Players
            Lawful player1 = new Lawful("Matt", true);
            Lawful player2 = new Lawful("Connor", false);
            Lawful player3 = new Lawful("David", true);
            Lawful player4 = new Lawful("Henry", false);
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
            players.Add(player4);
            //Create Game
            Game game = new Game(players);
            //Bidding
            game.Rounds.Add(new Round(players));
            game.CurrentRound.PerformBidding();
            Console.WriteLine("The Contract is " + game.CurrentRound.Bid + " bid by " + game.CurrentRound.HighestBidder.ToString());
            //Teardown
            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }
    }
}
