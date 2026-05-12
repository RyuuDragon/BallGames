using BallGames.Common;
using Timer = System.Windows.Forms.Timer;

namespace BilliardBallsWinFormsApp
{
    public partial class MainForm : Form
    {
        private readonly Timer _timer;
        private readonly List<BilliardBall> _billiardBalls = [];
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
                for (var i = 0; i < _billiardBalls.Count; i++)
                {
                    _billiardBalls[i].Move();
                }

                Invalidate();
            };

            _timer.Start();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            for (var i = 0; i < 10; i++)
            {
                var billiardBall = new BilliardBall(this, Brushes.DeepSkyBlue);
                billiardBall.Hit += BilliardBall_Hit;
                _billiardBalls.Add(billiardBall);
            }

            _timer.Start();
        }

        private void BilliardBall_Hit(object? sender, HitEventArgs e)
        {
            switch (e.Side)
            {
                case Side.Left: leftLabel.Text = (int.Parse(leftLabel.Text) + 1).ToString(); break;
                case Side.Right: rightLabel.Text = (int.Parse(rightLabel.Text) + 1).ToString(); break;
                case Side.Top: topLabel.Text = (int.Parse(topLabel.Text) + 1).ToString(); break;
                case Side.Bottom: bottomLabel.Text = (int.Parse(bottomLabel.Text) + 1).ToString(); break;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            for (var i = 0; i < _billiardBalls.Count; i++)
            {
                _billiardBalls[i].Draw(e.Graphics);
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
