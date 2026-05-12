namespace BallGames.Common
{
    public class BilliardBall : RandomMoveBall
    {
        public event EventHandler<HitEventArgs> Hit;
        private readonly Brush _brush;

        public BilliardBall(Form form, Brush brush) : base(form)
        {
            radius = 30;
            _brush = brush;

            if (_brush is SolidBrush solidBrush)
            {
                var color = solidBrush.Color;

                if (color == Color.DeepSkyBlue)
                {
                    centerX = _random.Next(radius, form.ClientSize.Width / 2 - radius);
                }
                else
                {
                    centerX = _random.Next(form.ClientSize.Width / 2 + radius, form.ClientSize.Width - radius);
                }
            }
        }

        protected override void Go()
        {
            base.Go();
            if (IsLeft())
            {
                centerX = radius;
                vx = -vx;
                Hit.Invoke(this, new HitEventArgs(Side.Left));
            }

            if (IsRight())
            {
                centerX = _form.ClientSize.Width - radius;
                vx = -vx;
                Hit.Invoke(this, new HitEventArgs(Side.Right));
            }

            if (IsTop())
            {
                centerY = radius;
                vy = -vy;
                Hit.Invoke(this, new HitEventArgs(Side.Top));
            }

            if (IsBottom())
            {
                centerY = _form.ClientSize.Height - radius;
                vy = -vy;
                Hit.Invoke(this, new HitEventArgs(Side.Bottom));
            }
        }

        public override void Move()
        {
            Go();
        }

        public void Draw(Graphics graphics)
        {
            var rectangle = new RectangleF(centerX - radius, centerY - radius, radius * 2, radius * 2);
            graphics.FillEllipse(_brush, rectangle);
        }

        public bool IsLeftOfCenter()
        {
            return centerX + radius < _form.ClientSize.Width / 2;
        }

        public bool IsRightOfCenter()
        {
            return centerX - radius > _form.ClientSize.Width / 2;
        }

        public Brush GetBrush()
        {
            return _brush;
        }
    }
}
