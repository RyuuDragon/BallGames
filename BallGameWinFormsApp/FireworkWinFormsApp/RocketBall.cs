using BallGames.Common;

namespace FireworkWinFormsApp
{
    public class RocketBall : Ball
    {
        private int targetY;
        private SolidBrush brush;
        private readonly Random random = new();

        public RocketBall(Form form, int targetX, int targetY) : base(form)
        {
            var r = random.Next(256);
            var g = random.Next(256);
            var b = random.Next(256);
            brush = new SolidBrush(Color.FromArgb(r, g, b));

            centerX = targetX;
            centerY = form.ClientSize.Height;
            this.targetY = targetY;

            radius = 15;
            vy = -Math.Abs(vy);
            vx = 0;
        }

        public override void Move()
        {
            Go();
        }

        public bool IsFlew()
        {
            return targetY >= centerY;
        }

        protected override void Go()
        {
            base.Go();
        }

        public void Draw(Graphics graphics)
        {
            if (targetY < centerY)
            {
                var rectangle = new RectangleF(centerX - radius, centerY - radius, radius * 2, radius * 2);
                graphics.FillEllipse(brush, rectangle);
            }
        }
    }
}
