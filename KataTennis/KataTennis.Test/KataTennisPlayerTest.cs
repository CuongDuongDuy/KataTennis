using KataTennis.App;
using NUnit.Framework;

namespace KataTennis.Test
{
    [TestFixture]
    public class KataTennisPlayerTest
    {

        [SetUp]
        public void Initialize()
        {
        }

        [Test]
        public void NameShouldBeSameAsInCtor()
        {
            const string name = "Cuong Duong";
            var player = new KataTennisPlayer(name);
            Assert.AreEqual(name, player.Name);
        }
    }
}
