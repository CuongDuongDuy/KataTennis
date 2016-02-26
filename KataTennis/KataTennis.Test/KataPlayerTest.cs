using KataTennis.App;
using NUnit.Framework;

namespace KataTennis.Test
{
    [TestFixture]
    public class KataPlayerTest
    {
        private KataPlayer kataPlayer;

        [SetUp]
        public void Initialize()
        {
            kataPlayer = new KataPlayer("Test");
        }

        [Test]
        public void ShouldIntroduceInTemplate()
        {
            const string name = "Cuong Duong";
            var expectedResult = string.Format("Name: {0}", name);
            var player = new KataPlayer(name);
            var result = player.GetInformation();
            Assert.AreEqual(expectedResult, result);
        }
    }
}
