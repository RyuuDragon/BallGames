namespace BallGames.Common
{
    public class HitEventArgs
    {
        public Side Side;

        public HitEventArgs(Side side)
        {
            Side = side;
        }
    }

    public enum Side
    {
        Left,
        Right,
        Top,
        Bottom
    }
}
