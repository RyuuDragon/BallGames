using Timer = System.Windows.Forms.Timer;

namespace BallGames.Common
{
    public class Ball
    {
        protected readonly Form _form;
        protected float centerX = 100;
        protected float centerY = 100;
        protected int radius = 35;
        protected float vx = 10;
        protected float vy = 15;
        private readonly Timer _timer;

        public Ball(Form form)
        {
            _form = form;

            _timer = new Timer
            {
                Interval = 10
            };

            _timer.Tick += Timer_Tick;
        }

        public virtual void Move()
        {
            Clear();
            Go();
            Show();
        }

        public bool IsVisible(int pointX, int pointY)
        {
            return Math.Pow(centerX - pointX, 2) + Math.Pow(centerY - pointY, 2) <= Math.Pow(radius, 2);
        }

        public bool OnForm()
        {
            return !IsLeft() && !IsRight() && !IsTop() && !IsBottom();
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        public bool IsNotStop()
        {
            return _timer.Enabled;
        }

        public bool IsLeft()
        {
            return centerX <= radius;
        }

        public bool IsRight()
        {
            return centerX >= _form.ClientSize.Width - radius;
        }

        public bool IsTop()
        {
            return centerY <= radius;
        }

        public bool IsBottom()
        {
            return centerY >= _form.ClientSize.Height - radius;
        }

        public void Show()
        {
            using var brush = new SolidBrush(Color.DeepSkyBlue);
            Draw(brush);
        }

        protected virtual void Go()
        {
            centerX += vx;
            centerY += vy;
        }

        private void Clear()
        {
            using var brush = new SolidBrush(_form.BackColor);
            Draw(brush);
        }

        private void Draw(Brush brush)
        {
            var graphics = _form.CreateGraphics();
            var rectangle = new RectangleF(centerX - radius, centerY - radius, radius * 2, radius * 2);
            graphics.FillEllipse(brush, rectangle);
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            Move();
        }
    }
}
