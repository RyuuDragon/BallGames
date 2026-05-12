using BallGames.Common;

namespace AngryBirdsWinFormsApp
{
    public class Pig : RandomSizeAndPointBall
    {
        private readonly SolidBrush brush;
        public float CenterX { get; private set; }
        public float CenterY { get; private set; }
        public float Radius { get; private set; }

        public Pig(Form form) : base(form)
        {
            brush = new SolidBrush(Color.Pink);

            centerX = _random.Next(form.ClientSize.Width / 4, form.ClientSize.Width / 2);
            centerY = _random.Next(form.ClientSize.Height / 2, form.ClientSize.Height - 100);
            CenterX = centerX;
            CenterY = centerY;

            radius = 35;
            Radius = radius;
        }

        public void Draw(Graphics graphics)
        {
            var rectangle = new RectangleF(centerX - radius, centerY - radius, radius * 2, radius * 2);
            graphics.FillEllipse(brush, rectangle);
        }
    }
}
