namespace BallGames.Common
{
    public class RandomSizeAndPointBall : Ball
    {
        protected static  readonly Random _random = new();

        public RandomSizeAndPointBall(Form form) : base(form)
        {
            radius = _random.Next(10, 50);
            centerX = _random.Next(radius, form.ClientSize.Width - radius);
            centerY = _random.Next(radius, form.ClientSize.Height - radius);
        }
    }
}
