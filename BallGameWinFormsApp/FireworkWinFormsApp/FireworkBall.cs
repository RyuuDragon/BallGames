using BallGames.Common;

namespace FireworkWinFormsApp
{
    public class FireworkBall : RandomMoveBall
    {
        private const float g = 0.2f;
        private readonly SolidBrush brush;
        private readonly Random random = new();

        public FireworkBall(Form form, int centerX, int centerY) : base(form)
        {
            var r = random.Next(256);
            var g = random.Next(256);
            var b = random.Next(256);
            brush = new SolidBrush(Color.FromArgb(r, g, b));

            this.centerX = centerX;
            this.centerY = centerY;

            radius = 15;
            vy = -Math.Abs(vy);
        }

        public override void Move()
        {
            Go();
        }

        protected override void Go()
        {
            base.Go();
            vy += g;
        }

        public void Draw(Graphics graphics)
        {
            var rectangle = new RectangleF(centerX - radius, centerY - radius, radius * 2, radius * 2);
            graphics.FillEllipse(brush, rectangle);
        }
    }
}
