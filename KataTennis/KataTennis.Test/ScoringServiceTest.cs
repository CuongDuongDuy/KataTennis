using System;
using KataTennis.App;
using Moq;
using NUnit.Framework;

namespace KataTennis.Test
{
    [TestFixture]
    public class ScoringServiceTest
    {
        private KataScoringService kataScoringService;
        private KataPlayer player1;
        private KataPlayer player2;

        [SetUp]
        public void Initalize()
        {
            player1 = new KataPlayer("Player 1");
            player2 = new KataPlayer("Player 2");
            kataScoringService = new KataScoringService(player1, player2);
        }

        [Test]
        public void ShouldReturnFalseIfPlayerNumberEqual0()
        {
            //arrange
            const int playerNumber = 0;
            //act
            var result = kataScoringService.GetPoint(playerNumber);
            //assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void ShouldReturnTrueIfPlayerNumberEqual1()
        {
            const int playerNumber = 1;
            var result = kataScoringService.GetPoint(playerNumber);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void ShouldReturnTrueIfPlayerNumberEqual2()
        {
            const int playerNumber = 2;
            var result = kataScoringService.GetPoint(playerNumber);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void ShouldReturnTrueIfPlayerNumberGreaterThan2()
        {
            const int playerNumber = 3;
            var result = kataScoringService.GetPoint(playerNumber);
            Assert.AreEqual(false, result);
        }
    }
}
