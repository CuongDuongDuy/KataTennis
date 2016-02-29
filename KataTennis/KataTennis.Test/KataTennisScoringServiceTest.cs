using System;
using System.Runtime.Serialization.Formatters;
using KataTennis.App;
using KataTennis.App.Contracts;
using Moq;
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
        public void DeuceShouldTrue()
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
        public bool DeuceShouldFalse(int player1Point, int player2Point)
        {
            player1.Point = player1Point;
            player2.Point = player2Point;
            var result = kataScoringService.CheckForInDuece();
            return result;
        }


        [TestCase(KataTennisPoint.Forty + 1, KataTennisPoint.Forty, Result = "Player 1")]
        [TestCase(KataTennisPoint.Forty, KataTennisPoint.Forty + 1, Result = "Player 2")]
        public string PlayerInAdvangeShouldBeNotNull(int player1Point, int player2Point)
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
        public KataTennisPlayer PlayerInAdvangeShouldBeNull(int player1Point, int player2Point)
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
        public Player WinnerShoudBeNull(int player1Point, int player2Point)
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
        public string WinnerShoudBeNotNull(int player1Point, int player2Point)
        {
            player1.Point = player1Point;
            player2.Point = player2Point;
            var result = kataScoringService.GetWinner().Name;
            return result;
        }

        [TestCase(KataTennisPoint.Love, Result = "Love")]
        [TestCase(KataTennisPoint.Fifteen, Result = "Fifteen")]
        [TestCase(KataTennisPoint.Thirty, Result = "Thirty")]
        [TestCase(KataTennisPoint.Forty, Result = "Forty")]
        [TestCase(4, Result = "Forty")]
        [TestCase(5, Result = "Forty")]
        public string PointNameShouldBetweenLoveAndForty(int playerPoint)
        {
            return KataTennisPoint.PointNames[Math.Min(playerPoint, KataTennisPoint.Forty)];
        }


        [Test]
        public void Player1PointShouldIncreaseAndPlayer2ShouldDecrease()
        {
            player1.Point = KataTennisPoint.Love;
            player2.Point = KataTennisPoint.Love;
            kataScoringService.GainPointForPlayer(1);
            Assert.AreEqual(player1.Point, KataTennisPoint.Fifteen);
            Assert.AreEqual(player2.Point, KataTennisPoint.Love);

            player1.Point = KataTennisPoint.Fifteen;
            player2.Point = KataTennisPoint.Fifteen;
            kataScoringService.GainPointForPlayer(1);
            Assert.AreEqual(player1.Point, KataTennisPoint.Thirty);
            Assert.AreEqual(player2.Point, KataTennisPoint.Fifteen);

            player1.Point = KataTennisPoint.Thirty;
            player2.Point = KataTennisPoint.Fifteen;
            kataScoringService.GainPointForPlayer(1);
            Assert.AreEqual(player1.Point, KataTennisPoint.Forty);
            Assert.AreEqual(player2.Point, KataTennisPoint.Fifteen);

            player1.Point = KataTennisPoint.Forty;
            player2.Point = KataTennisPoint.Fifteen;
            kataScoringService.GainPointForPlayer(1);
            Assert.AreEqual(player1.Point, KataTennisPoint.Forty + 1);
            Assert.AreEqual(player2.Point, KataTennisPoint.Fifteen);

            player1.Point = KataTennisPoint.Forty;
            player2.Point = KataTennisPoint.Forty + 1;
            kataScoringService.GainPointForPlayer(1);
            Assert.AreEqual(player1.Point, KataTennisPoint.Forty);
            Assert.AreEqual(player2.Point, KataTennisPoint.Forty);
        }


        [Test]
        public void Player2PointShouldIncreaseAndPlayer1ShouldDecrease()
        {
            player1.Point = KataTennisPoint.Love;
            player2.Point = KataTennisPoint.Love;
            kataScoringService.GainPointForPlayer(2);
            Assert.AreEqual(player1.Point, KataTennisPoint.Love);
            Assert.AreEqual(player2.Point, KataTennisPoint.Fifteen);

            player1.Point = KataTennisPoint.Fifteen;
            player2.Point = KataTennisPoint.Fifteen;
            kataScoringService.GainPointForPlayer(2);
            Assert.AreEqual(player1.Point, KataTennisPoint.Fifteen);
            Assert.AreEqual(player2.Point, KataTennisPoint.Thirty);

            player1.Point = KataTennisPoint.Thirty;
            player2.Point = KataTennisPoint.Fifteen;
            kataScoringService.GainPointForPlayer(2);
            Assert.AreEqual(player1.Point, KataTennisPoint.Thirty);
            Assert.AreEqual(player2.Point, KataTennisPoint.Thirty);

            player1.Point = KataTennisPoint.Forty;
            player2.Point = KataTennisPoint.Fifteen;
            kataScoringService.GainPointForPlayer(2);
            Assert.AreEqual(player1.Point, KataTennisPoint.Forty);
            Assert.AreEqual(player2.Point, KataTennisPoint.Thirty);

            player1.Point = KataTennisPoint.Forty;
            player2.Point = KataTennisPoint.Forty + 1;
            kataScoringService.GainPointForPlayer(2);
            Assert.AreEqual(player1.Point, KataTennisPoint.Forty);
            Assert.AreEqual(player2.Point, KataTennisPoint.Forty + 2);
        }
    }
}
