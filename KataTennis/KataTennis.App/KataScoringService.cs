using System;
using System.Collections.Generic;

namespace KataTennis.App
{
    public class KataScoringService
    {
        private KataPlayer Player1 { get; set; }
        private KataPlayer Player2 { get; set; }

        private bool IsDeuce
        {
            get
            {
                return (Player1.Point == KataPoints.Forteen && Player2.Point == KataPoints.Forteen);
            }
        }

        public KataScoringService(KataPlayer player1, KataPlayer player2)
        {
            Player1 = player1;
            Player2 = player2;
        }

        public void UpdatePointForPlayerNumber(int playerNumber)
        {
            if (playerNumber >= 1 && playerNumber <= 2)
            {
                UpdatePointsForAllPlayers(playerNumber);
            }
        }

        private void UpdatePointsForAllPlayers(int gainPlayerNumber)
        {
            if (gainPlayerNumber == 1)
            {
                Player1.GainPoint();
                Player2.LosePoint();
            }
            else
            {
                Player1.LosePoint();
                Player2.GainPoint();
            }
        }

        private KataPlayer GetWinnder()
        {
            if (IsDeuce)
            {
                Console.WriteLine("In deuce");
            }

        }

        

        

    }
}
