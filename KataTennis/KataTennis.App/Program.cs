using System;

namespace KataTennis.App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var playerA = new KataTennisPlayer("Zeeshan");
            var playerB = new KataTennisPlayer("Matthew");
            var scoringService = new KataTennisScoringService(playerA, playerB);
            Console.WriteLine("Player 1: {0} vs Player 2: {1}", playerA.Name, playerB.Name);
            while (true)
            {
                Console.Write("Gain Point for Player (1/2): ");
                scoringService.GainPointForPlayer(Console.ReadKey().KeyChar - 48);
                Console.WriteLine();

                Console.WriteLine("===> Current Results: {0}", scoringService.GetCurrentResults());

                if (scoringService.CheckForInDuece())
                {
                    Console.WriteLine("===> In duece");
                }

                var advangedPlayer = scoringService.GetPlayerInAdvange();
                if (advangedPlayer != null)
                {
                    Console.WriteLine("===> {0} is in advange", advangedPlayer.Name);
                }

                var winner = scoringService.GetWinner();
                if (winner != null)
                {
                    Console.WriteLine("===> {0} is a winner", winner.Name);
                    return;
                }
            }
        }
    }
}
