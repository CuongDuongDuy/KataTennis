using System;
using KataTennis.App.Contracts;

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
            while (scoringService.GetWinner() == null)
            {
                Console.Write("Gain Point for Player (1/2): ");
                scoringService.GainPointForPlayer(Console.ReadKey().KeyChar - 48);
                Console.WriteLine();
                scoringService.ShowCurrentResults();
            }
        }
    }
}
