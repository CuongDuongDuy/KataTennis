using KataTennis.App.Contracts;

namespace KataTennis.App
{
    public class KataTennisPlayer : Player
    {
        public int Point { get; set; }
        public KataTennisPlayer(string playerName) : base(playerName)
        {
        }
    }
}