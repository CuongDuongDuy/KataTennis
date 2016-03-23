using System;
using KataTennis.App;
using KataTennis.App.Contracts;
using NUnit.Framework;

namespace KataTennis.Test
{
    [TestFixture]
    public class KataTennisScoringServiceTest
    {
        private KataTennisScoringService kataScoringService;
        private KataTennisPlayer player1;
        private KataTennisPlayer player2;


        [SetUp]
        public void Initalize()
        {
            player1 = new KataTennisPlayer("Player 1");
            player2 = new KataTennisPlayer("Player 2");
            kataScoringService = new KataTennisScoringService(player1, player2);
        }


        [Test]
        public void CheckForInDuece_Should_True()
        {
            //arrange
            player1.Point = KataTennisPoint.Forty;
            player2.Point = KataTennisPoint.Forty;
            //act
            var result = kataScoringService.CheckForInDuece();
            //assert
            Assert.AreEqual(true, result);
        }


        [TestCase(KataTennisPoint.Love, KataTennisPoint.Love, Result = false)]
        [TestCase(KataTennisPoint.Love, KataTennisPoint.Fifteen, Result = false)]
        [TestCase(KataTennisPoint.Love, KataTennisPoint.Thirty, Result = false)]
        [TestCase(KataTennisPoint.Love, KataTennisPoint.Forty, Result = false)]
        [TestCase(KataTennisPoint.Fifteen, KataTennisPoint.Love, Result = false)]
        [TestCase(KataTennisPoint.Fifteen, KataTennisPoint.Fifteen, Result = false)]
        [TestCase(KataTennisPoint.Fifteen, KataTennisPoint.Thirty, Result = false)]
        [TestCase(KataTennisPoint.Fifteen, KataTennisPoint.Forty, Result = false)]
        [TestCase(KataTennisPoint.Thirty, KataTennisPoint.Love, Result = false)]
        [TestCase(KataTennisPoint.Thirty, KataTennisPoint.Fifteen, Result = false)]
        [TestCase(KataTennisPoint.Thirty, KataTennisPoint.Thirty, Result = false)]
        [TestCase(KataTennisPoint.Thirty, KataTennisPoint.Forty, Result = false)]
        [TestCase(KataTennisPoint.Forty, KataTennisPoint.Love, Result = false)]
        [TestCase(KataTennisPoint.Forty, KataTennisPoint.Fifteen, Result = false)]
        [TestCase(KataTennisPoint.Forty, KataTennisPoint.Thirty, Result = false)]
        public bool CheckForInDuece_Should_False(int player1Point, int player2Point)
        {
            player1.Point = player1Point;
            player2.Point = player2Point;
            var result = kataScoringService.CheckForInDuece();
            return result;
        }


        [TestCase(KataTennisPoint.Forty + 1, KataTennisPoint.Forty, Result = "Player 1")]
        [TestCase(KataTennisPoint.Forty, KataTennisPoint.Forty + 1, Result = "Player 2")]
        public string GetPlayerInAdvange_Should_Be_Not_Null(int player1Point, int player2Point)
        {
            player1.Point = player1Point;
            player2.Point = player2Point;
            var result = kataScoringService.GetPlayerInAdvange();
            return result.Name;
        }

        
        [TestCase(KataTennisPoint.Forty, KataTennisPoint.Forty, Result = null)]
        [TestCase(KataTennisPoint.Forty, KataTennisPoint.Fifteen, Result = null)]
        [TestCase(KataTennisPoint.Forty, KataTennisPoint.Thirty, Result = null)]
        [TestCase(KataTennisPoint.Forty, KataTennisPoint.Love, Result = null)]
        [TestCase(KataTennisPoint.Forty, KataTennisPoint.Fifteen, Result = null)]
        [TestCase(KataTennisPoint.Forty, KataTennisPoint.Thirty, Result = null)]
        [TestCase(KataTennisPoint.Forty, KataTennisPoint.Love, Result = null)]
        [TestCase(KataTennisPoint.Forty + 2, KataTennisPoint.Forty, Result = null)]
        [TestCase(KataTennisPoint.Forty, KataTennisPoint.Forty + 2, Result = null)]
        public KataTennisPlayer GetPlayerInAdvange_Should_Be_Null(int player1Point, int player2Point)
        {
            player1.Point = player1Point;
            player2.Point = player2Point;
            var result = kataScoringService.GetPlayerInAdvange();
            return result;
        }


        [TestCase(KataTennisPoint.Love, KataTennisPoint.Love, Result = null)]
        [TestCase(KataTennisPoint.Fifteen, KataTennisPoint.Love, Result = null)]
        [TestCase(KataTennisPoint.Thirty, KataTennisPoint.Love, Result = null)]
        [TestCase(KataTennisPoint.Love, KataTennisPoint.Fifteen, Result = null)]
        [TestCase(KataTennisPoint.Fifteen, KataTennisPoint.Fifteen, Result = null)]
        [TestCase(KataTennisPoint.Thirty, KataTennisPoint.Fifteen, Result = null)]
        [TestCase(KataTennisPoint.Love, KataTennisPoint.Thirty, Result = null)]
        [TestCase(KataTennisPoint.Fifteen, KataTennisPoint.Thirty, Result = null)]
        [TestCase(KataTennisPoint.Thirty, KataTennisPoint.Thirty, Result = null)]
        [TestCase(KataTennisPoint.Forty, KataTennisPoint.Thirty, Result = null)]
        [TestCase(KataTennisPoint.Forty, KataTennisPoint.Forty, Result = null)]
        [TestCase(4, KataTennisPoint.Forty, Result = null)]
        [TestCase(KataTennisPoint.Forty, KataTennisPoint.Forty + 1, Result = null)]
        public Player GetWinner_Shoud_Be_Null(int player1Point, int player2Point)
        {
            player1.Point = player1Point;
            player2.Point = player2Point;
            var result = kataScoringService.GetWinner();
            return result;
        }


        [TestCase(KataTennisPoint.Forty, KataTennisPoint.Love, Result = "Player 1")]
        [TestCase(KataTennisPoint.Forty, KataTennisPoint.Fifteen, Result = "Player 1")]
        [TestCase(4, KataTennisPoint.Thirty, Result = "Player 1")]
        [TestCase(5, KataTennisPoint.Forty, Result = "Player 1")]
        [TestCase(KataTennisPoint.Love, KataTennisPoint.Forty, Result = "Player 2")]
        [TestCase(KataTennisPoint.Fifteen, KataTennisPoint.Forty, Result = "Player 2")]
        [TestCase(KataTennisPoint.Thirty, KataTennisPoint.Forty + 1, Result = "Player 2")]
        [TestCase(KataTennisPoint.Forty, KataTennisPoint.Forty + 2, Result = "Player 2")]
        public string GetWinner_Shoud_Be_Not_Null(int player1Point, int player2Point)
        {
            player1.Point = player1Point;
            player2.Point = player2Point;
            var result = kataScoringService.GetWinner().Name;
            return result;
        }


        [TestCase(KataTennisPoint.Love, KataTennisPoint.Love, KataTennisPoint.Fifteen, KataTennisPoint.Love)]
        [TestCase(KataTennisPoint.Fifteen, KataTennisPoint.Fifteen, KataTennisPoint.Thirty, KataTennisPoint.Fifteen)]
        [TestCase(KataTennisPoint.Thirty, KataTennisPoint.Fifteen, KataTennisPoint.Forty, KataTennisPoint.Fifteen)]
        [TestCase(KataTennisPoint.Forty, KataTennisPoint.Fifteen, KataTennisPoint.Forty + 1, KataTennisPoint.Fifteen)]
        [TestCase(KataTennisPoint.Forty, KataTennisPoint.Forty + 1, KataTennisPoint.Forty, KataTennisPoint.Forty)]
        public void GainPointForPlayer_1(int player1Point, int player2Point, int expectedPlayer1Point, int expectedPlayer2Point)
        {
            player1.Point = KataTennisPoint.Love;
            player2.Point = KataTennisPoint.Love;
            kataScoringService.GainPointForPlayer(1);
            Assert.AreEqual(player1.Point, KataTennisPoint.Fifteen);
            Assert.AreEqual(player2.Point, KataTennisPoint.Love);
        }


        [TestCase(KataTennisPoint.Love, KataTennisPoint.Love,KataTennisPoint.Love, KataTennisPoint.Fifteen)]
        [TestCase(KataTennisPoint.Fifteen, KataTennisPoint.Fifteen, KataTennisPoint.Fifteen, KataTennisPoint.Thirty)]
        [TestCase(KataTennisPoint.Thirty, KataTennisPoint.Fifteen, KataTennisPoint.Thirty, KataTennisPoint.Thirty)]
        [TestCase(KataTennisPoint.Forty, KataTennisPoint.Fifteen, KataTennisPoint.Forty, KataTennisPoint.Thirty)]
        [TestCase(KataTennisPoint.Forty, KataTennisPoint.Forty + 1, KataTennisPoint.Forty, KataTennisPoint.Forty + 2)]
        public void GainPointForPlayer_2(int player1Point, int player2Point, int expectedPlayer1Point, int expectedPlayer2Point)
        {
            player1.Point = player1Point;
            player2.Point = player2Point;
            kataScoringService.GainPointForPlayer(2);
            Assert.AreEqual(player1.Point, expectedPlayer1Point);
            Assert.AreEqual(player2.Point, expectedPlayer2Point);
        }

        [TestCase(KataTennisPoint.Thirty, KataTennisPoint.Forty + 1, Result = "Player 1: Thirty - Player 2: Forty")]
        [TestCase(KataTennisPoint.Forty, KataTennisPoint.Forty + 1, Result = "Player 1: Forty - Player 2: Forty")]
        [TestCase(KataTennisPoint.Forty, KataTennisPoint.Forty + 2, Result = "Player 1: Forty - Player 2: Forty")]
        [TestCase(KataTennisPoint.Forty + 1, KataTennisPoint.Thirty, Result = "Player 1: Forty - Player 2: Thirty")]
        [TestCase(KataTennisPoint.Forty + 1, KataTennisPoint.Forty, Result = "Player 1: Forty - Player 2: Forty")]
        [TestCase(KataTennisPoint.Forty + 2, KataTennisPoint.Forty, Result = "Player 1: Forty - Player 2: Forty")]
        public string GetCurrentResults_Should_In_Template(int player1Point, int player2Point)
        {
            player1.Point = player1Point;
            player2.Point = player2Point;
            var result = kataScoringService.GetCurrentResults();
            return result;
        }
    }
}
