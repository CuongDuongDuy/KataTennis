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

        [TestCase("Cuong Duong", Result = "Cuong Duong")]
        [TestCase("Cuong Duong 1", Result = "Cuong Duong 1")]
        [TestCase("Cuong Duong 2", Result = "Cuong Duong 2")]
        [TestCase("Cuong Duong 3", Result = "Cuong Duong 3")]
        public string Name_Should_Be_Same_As_Initial(string name)
        {
            var player = new KataTennisPlayer(name);
            return player.Name;
        }
    }
}
