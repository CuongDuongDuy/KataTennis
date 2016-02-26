using System;

namespace KataTennis.App
{
    public abstract class Player
    {
        public string Name { get; private set; }
        public int Point { get; set; }

        public abstract void GainPoint();

        protected Player(string playerName)
        {
            Name = playerName;
        }
        public string GetInformation()
        {
            var result = string.Format("Name: {0}", Name);
            return result;
        }
    }

    public class KataPlayer : Player
    {
        public int Advange { get; set; }

        public KataPlayer(string playerName) : base(playerName)
        {
        }

        public override void GainPoint()
        {
            if (Point == KataPoints.Forteen)
            {
                Advange++;
            }
            else
            {
                Point++;
            }

        }
        public void LosePoint()
        {
            if (Advange > 0)
            {
                Advange--;
            }
            else
            {
                Point--;
            }

        }
    }
}