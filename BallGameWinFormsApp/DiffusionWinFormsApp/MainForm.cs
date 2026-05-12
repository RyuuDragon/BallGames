using BallGames.Common;
using Timer = System.Windows.Forms.Timer;

namespace DiffusionWinFormsApp
{
    public partial class MainForm : Form
    {
        private readonly Timer _timer;
        private readonly List<BilliardBall> balls = [];
        private Point lastPoint;

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
                if (IsDiffusion())
                {
                    _timer.Stop();
                }

                for (var i = 0; i < balls.Count; i++)
                {
                    balls[i].Move();
                }

                Invalidate();
            };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CreateBalls();
        }

        private void BlueBilliardBall_Hit(object? sender, HitEventArgs e)
        {
            switch (e.Side)
            {
                case Side.Left: leftBlueLabel.Text = (int.Parse(leftBlueLabel.Text) + 1).ToString(); break;
                case Side.Right: rightBlueLabel.Text = (int.Parse(rightBlueLabel.Text) + 1).ToString(); break;
                case Side.Top: topBlueLabel.Text = (int.Parse(topBlueLabel.Text) + 1).ToString(); break;
                case Side.Bottom: bottomBlueLabel.Text = (int.Parse(bottomBlueLabel.Text) + 1).ToString(); break;
            }
        }

        private void RedBilliardBall_Hit(object? sender, HitEventArgs e)
        {
            switch (e.Side)
            {
                case Side.Left: leftRedLabel.Text = (int.Parse(leftBlueLabel.Text) + 1).ToString(); break;
                case Side.Right: rightRedLabel.Text = (int.Parse(rightBlueLabel.Text) + 1).ToString(); break;
                case Side.Top: topRedLabel.Text = (int.Parse(topBlueLabel.Text) + 1).ToString(); break;
                case Side.Bottom: bottomRedLabel.Text = (int.Parse(bottomBlueLabel.Text) + 1).ToString(); break;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.DrawLine(Pens.Black, Width / 2, 0, Width / 2, Height);

            for (var i = 0; i < balls.Count; i++)
            {
                balls[i].Draw(e.Graphics);
            }
        }

        private bool IsDiffusion()
        {
            var leftHalfBlueBallsCount = 0;
            var leftHalfRedBallsCount = 0;
            var rightHalfBlueBallsCount = 0;
            var rightHalfRedBallsCount = 0;

            foreach (var ball in balls)
            {
                if (ball.IsLeftOfCenter())
                {
                    if (ball.GetBrush() == Brushes.DeepSkyBlue)
                    {
                        leftHalfBlueBallsCount++;
                    }
                    else
                    {
                        leftHalfRedBallsCount++;
                    }
                }

                if (ball.IsRightOfCenter())
                {
                    if (ball.GetBrush() == Brushes.DeepSkyBlue)
                    {
                        rightHalfBlueBallsCount++;
                    }
                    else
                    {
                        rightHalfRedBallsCount++;
                    }
                }
            }

            int totalRed = leftHalfRedBallsCount + rightHalfRedBallsCount;
            int totalBlue = leftHalfBlueBallsCount + rightHalfBlueBallsCount;

            if (totalRed != totalBlue)
            {
                return false;
            }

            if (leftHalfRedBallsCount == rightHalfRedBallsCount &&
                leftHalfBlueBallsCount == rightHalfBlueBallsCount)
            {
                return true;
            }

            return false;
        }

        private void switchButton_Click(object sender, EventArgs e)
        {
            if (!_timer.Enabled && !IsDiffusion())
            {
                _timer.Start();
            }
            else
            {
                _timer.Stop();
            }
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            _timer.Stop();

            leftBlueLabel.Text = "0";
            rightBlueLabel.Text = "0";
            topBlueLabel.Text = "0";
            bottomBlueLabel.Text = "0";

            leftRedLabel.Text = "0";
            rightRedLabel.Text = "0";
            topRedLabel.Text = "0";
            bottomRedLabel.Text = "0";

            balls.Clear();
            CreateBalls();

            Invalidate();
        }

        private void CreateBalls()
        {
            for (var i = 0; i < 10; i++)
            {
                var blueBall = new BilliardBall(this, Brushes.DeepSkyBlue);
                blueBall.Hit += BlueBilliardBall_Hit;
                balls.Add(blueBall);

                var redBall = new BilliardBall(this, Brushes.Red);
                redBall.Hit += RedBilliardBall_Hit;
                balls.Add(redBall);
            }
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
    }
}
