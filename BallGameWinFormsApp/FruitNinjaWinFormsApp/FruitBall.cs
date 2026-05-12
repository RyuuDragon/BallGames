using BallGames.Common;

namespace FruitNinjaWinFormsApp
{
    public class FruitBall : RandomMoveBall
    {
        private bool isFalling = false;
        protected float g = 0.2f;
        protected SolidBrush brush;
        public bool CountedMistake { get; set; } = false;
        public float Speed { get; set; } = 1.0f;

        public FruitBall(Form form) : base(form)
        {
            var r = _random.Next(1, 255);
            var g = _random.Next(1, 255);
            var b = _random.Next(1, 255);
            brush = new SolidBrush(Color.FromArgb(r, g, b));

            centerY = form.ClientSize.Height;
            centerX = _random.Next(form.ClientSize.Width / 4, form.ClientSize.Width / 2);

            radius = _random.Next(20, 35);
            vx = _random.Next(-1, 2);
            vy = -Math.Abs(5);
        }

        public override void Move()
        {
            Go();
        }

        public int GetRadius()
        {
            return radius;
        }

        public Color GetColor()
        {
            return brush.Color;
        }

        public virtual void Draw(Graphics graphics)
        {
            var rectangle = new RectangleF(centerX - radius, centerY - radius, radius * 2, radius * 2);
            graphics.FillEllipse(brush, rectangle);
        }

        public bool IsFalling()
        {
            return isFalling;
        }

        protected override void Go()
        {
            centerX += vx * Speed;
            centerY += vy * Speed;

            if (vy > 0 && !isFalling)
            {
                isFalling = true;
            }

            if (centerY < _form.ClientSize.Height / 2)
            {
                vy += g;
            }
        }
    }
}
