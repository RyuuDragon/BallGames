using Timer = System.Windows.Forms.Timer;

namespace FireworkWinFormsApp
{
    public partial class MainForm : Form
    {
        private Point lastPoint;
        private readonly Timer _timer;
        private readonly List<FireworkBall> balls = [];
        private readonly List<RocketBall> rocketBalls = [];
        private readonly Random random = new();
        private int pointX;
        private int pointY;

        public MainForm()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();

            _timer = new Timer
            {
                Interval = 10
            };

            _timer.Tick += (s, e) =>
            {
                for (var i = rocketBalls.Count - 1; i >= 0; i--)
                {
                    var rocketBall = rocketBalls[i];
                    rocketBall.Move();

                    if (rocketBall.IsFlew())
                    {
                        for (var j = 0; j < random.Next(5, 16); j++)
                        {
                            var ball = new FireworkBall(this, pointX, pointY);
                            balls.Add(ball);
                        }

                        rocketBalls.RemoveAt(i);
                    }
                }

                foreach (var ball in balls)
                {
                    ball.Move();
                }

                Invalidate();
            };
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            var rocketBall = new RocketBall(this, e.X, e.Y);
            rocketBalls.Add(rocketBall);

            pointX = e.X;
            pointY = e.Y;

            _timer.Start();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var x = e.X - lastPoint.X;
                var y = e.Y - lastPoint.Y;

                Left += x;
                Top += y;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            foreach (var rocketBall in rocketBalls)
            {
                rocketBall.Draw(e.Graphics);
            }

            foreach (var ball in balls)
            {
                ball.Draw(e.Graphics);
            }
        }
    }
}
