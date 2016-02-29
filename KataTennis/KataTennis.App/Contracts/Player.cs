namespace KataTennis.App.Contracts
{
    public abstract class Player
    {
        public string Name { get; private set; }
        public int Point { get; set; }

        protected Player(string playerName)
        {
            Name = playerName;
        }
    }
}