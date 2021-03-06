﻿using System;
using KataTennis.App.Contracts;

namespace KataTennis.App
{
    public class KataTennisScoringService : IScoringService
    {
        public KataTennisPlayer Player1 { get; private set; }
        public KataTennisPlayer Player2 { get; private set; }

        public KataTennisScoringService(KataTennisPlayer player1, KataTennisPlayer player2)
        {
            Player1 = player1;
            Player2 = player2;
        }

        public Player GetWinner()
        {
            KataTennisPlayer leader, follower;
            if (Player1.Point > Player2.Point)
            {
                leader = Player1;
                follower = Player2;
            }
            else
            {
                leader = Player2;
                follower = Player1;
            }
            if (leader != null && follower != null)
            {
                return leader.Point - follower.Point >= 2 && leader.Point >= KataTennisPoint.Forty ? leader : null;
            }
            return null;
        }

        public string GetCurrentResults()
        {
            const string template = "{0}: {1} - {2}: {3}";
            var player1PointName = KataTennisPoint.PointNames[Math.Min(Player1.Point, KataTennisPoint.Forty)];
            var player2PointName = KataTennisPoint.PointNames[Math.Min(Player2.Point, KataTennisPoint.Forty)];
            var result = string.Format(template, Player1.Name, player1PointName,Player2.Name, player2PointName);
            return result;
        }

        public bool CheckForInDuece()
        {
            return Player1.Point == KataTennisPoint.Forty && Player2.Point == KataTennisPoint.Forty;
        }

        public KataTennisPlayer GetPlayerInAdvange()
        {
            var minPoint = Math.Min(Player1.Point, Player2.Point);

            if (minPoint == KataTennisPoint.Forty)
            {
                if (Player1.Point == minPoint + 1)
                {
                    return Player1;
                }
                if (Player2.Point == minPoint + 1)
                {
                    return Player2;
                }
            }
            return null;
        }

        public void GainPointForPlayer(int i)
        {
            if (i < 1 || i > 2) return;
            if (i == 1)
            {
                if (Player2.Point == KataTennisPoint.Forty + 1)
                {
                    Player2.Point--;
                }
                else
                {
                    Player1.Point = Math.Min(Player1.Point + 1, KataTennisPoint.Forty + 2);
                }

            }
            else
            {
                if (Player1.Point == KataTennisPoint.Forty + 1)
                {
                    Player1.Point--;
                }
                else
                {
                    Player2.Point = Math.Min(Player2.Point + 1 ,KataTennisPoint.Forty + 2);
                }
            }
        }
    }
}
