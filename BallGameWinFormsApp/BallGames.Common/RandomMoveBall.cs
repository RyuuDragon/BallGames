namespace BallGames.Common
{
    public class RandomMoveBall : RandomSizeAndPointBall
    {
        public RandomMoveBall(Form form) : base(form)
        {
            do
            {
                vx = _random.Next(-5, 6);
            } while (vx == 0);

            do
            {
                vy = _random.Next(-5, 6);
            } while (vy == 0);
        }
    }
}
