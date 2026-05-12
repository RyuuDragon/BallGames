using BallGames.Common;
using Timer = System.Windows.Forms.Timer;

namespace AngryBirdsWinFormsApp
{
    public class Bird : RandomMoveBall
    {
        public bool IsHit { get; private set; } = false;
        public bool IsStopped { get; set; } = false;
        public Pig Pig { get; set; }
        private readonly Timer _timer;
        private readonly SolidBrush brush;
        private const float G = 0.2f;
        private const float DesiredSpeed = 12f;
        private const float DecreaseSpeed = 0.7f;
        private const float StopThreshold = 0.7f;

        public Bird(Form form, Pig pig, Timer timer) : base(form)
        {
            _timer = timer;

            brush = new SolidBrush(Color.Red);

            Pig = pig;

            radius = 30;
            centerX = radius;
            centerY = form.ClientSize.Height - radius;
        }

        public void ResetPosition()
        {
            centerX = radius;
            centerY = _form.ClientSize.Height - radius;
            IsHit = false;
            IsStopped = false;
        }

        public override void Move()
        {
            if (!IsStopped)
            {
                Go();
            }
        }

        public void Draw(Graphics graphics)
        {
            var rectangle = new RectangleF(centerX - radius, centerY - radius, radius * 2, radius * 2);
            graphics.FillEllipse(brush, rectangle);
        }

        public void SetSpeed(int targetX, int targetY)
        {
            IsStopped = false;
            IsHit = false;

            float deltaX = targetX - centerX;
            float deltaY = targetY - centerY;

            float distance = (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            float directionX = deltaX / distance;
            float directionY = deltaY / distance;

            vx = directionX * DesiredSpeed;
            vy = directionY * DesiredSpeed;
        }

        protected override void Go()
        {
            base.Go();

            if (!IsHit && CheckCollisionWith())
            {
                vx = -Math.Abs(vx) * DecreaseSpeed;
                IsHit = true;
            }

            if (IsBottom())
            {
                vy = -Math.Abs(vy) * DecreaseSpeed;

                if (Math.Abs(vy) < StopThreshold && Math.Abs(vx) < StopThreshold)
                {
                    StopBall();
                    return;
                }

                if (Math.Abs(vx) < StopThreshold * 2)
                {
                    vx = 0;
                }
                else
                {
                    vx *= DecreaseSpeed;
                }
            }

            vy += G;
        }

        private void StopBall()
        {
            vx = 0;
            vy = 0;
            IsStopped = true;
            _timer.Stop();
        }

        private bool CheckCollisionWith()
        {
            double dx = centerX - Pig.CenterX;
            double dy = centerY - Pig.CenterY;
            double distance = Math.Sqrt(dx * dx + dy * dy);
            return distance <= radius + Pig.Radius;
        }
    }
}
