using Timer = System.Windows.Forms.Timer;

namespace FruitNinjaWinFormsApp
{
    public partial class MainForm : Form
    {
        private readonly List<FruitBall> _fruitBalls = [];
        private readonly List<CutBall> _cutBalls = [];
        private readonly List<BombBall> _bombBalls = [];
        private readonly List<BananBall> _bananBalls = [];
        private readonly Timer _timer;
        private readonly Timer _spawnTimer;
        private readonly Timer _spawnBombTimer;
        private readonly Timer _spawnBananTimer;
        private readonly Timer _slowSpeedDownTimer;
        private bool isCutting;
        private Point lastPoint;
        private int result = 0;
        private int mistakes = 0;

        public MainForm()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();

            _timer = new Timer
            {
                Interval = 10
            };

            _spawnTimer = new Timer
            {
                Interval = 500
            };

            _spawnBombTimer = new Timer
            {
                Interval = 15000
            };

            _spawnBananTimer = new Timer
            {
                Interval = 20000
            };

            _slowSpeedDownTimer = new Timer
            {
                Interval = 10000
            };

            WorkTimers();
        }

        private void WorkTimers()
        {
            _timer.Tick += (s, e) =>
            {
                MoveBalls();
                FixedMistakes();

                Invalidate();
            };

            _spawnTimer.Tick += (s, e) =>
            {
                var fruitBall = new FruitBall(this);
                _fruitBalls.Add(fruitBall);
            };

            _spawnBombTimer.Tick += (s, e) =>
            {
                var bombBall = new BombBall(this);
                _bombBalls.Add(bombBall);
            };

            _spawnBananTimer.Tick += (s, e) =>
            {
                var bananBall = new BananBall(this);
                _bananBalls.Add(bananBall);
            };

            _slowSpeedDownTimer.Tick += (s, e) =>
            {
                SetStartSpeed();
                _slowSpeedDownTimer.Stop();
            };
        }

        private void MoveBalls()
        {
            foreach (var fruit in _fruitBalls)
            {
                fruit.Move();
            }

            for (var i = 0; i < _cutBalls.Count; i++)
            {
                _cutBalls[i].Move();
            }

            for (var i = 0; i < _bombBalls.Count; i++)
            {
                _bombBalls[i].Move();
            }

            for (var i = 0; i < _bananBalls.Count; i++)
            {
                _bananBalls[i].Move();
            }
        }

        private void FixedMistakes()
        {
            foreach (var fruit in _fruitBalls)
            {
                if (!fruit.OnForm() && fruit.IsFalling() && !fruit.CountedMistake)
                {
                    mistakes++;
                    fruit.CountedMistake = true;

                    switch (mistakes)
                    {
                        case 1: wrongLabel.Text = "Промахи: Х 0 0"; break;
                        case 2: wrongLabel.Text = "Промахи: Х X 0"; break;
                        case 3: wrongLabel.Text = "Промахи: Х X X"; break;
                    }
                }

                if (mistakes == 3)
                {
                    RestartGame();
                    break;
                }
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            _spawnTimer.Start();
            _spawnBombTimer.Start();
            _spawnBananTimer.Start();
            _timer.Start();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isCutting = true;
                lastPoint = e.Location;
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isCutting = false;
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isCutting)
            {
                using (var g = CreateGraphics())
                {
                    g.DrawLine(Pens.Red, lastPoint, e.Location);
                }

                lastPoint = e.Location;

                ProcessCuttingBalls(e.X, e.Y);
            }
        }

        private void ProcessCuttingBalls(int pointX, int pointY)
        {
            for (int i = _fruitBalls.Count - 1; i >= 0; i--)
            {
                var fruit = _fruitBalls[i];

                if (fruit.IsVisible(pointX, pointY))
                {
                    var firstHalfBall = new CutBall(this, pointX, pointY, fruit.GetRadius(), fruit.GetColor(), 2);
                    var secondHalfBall = new CutBall(this, pointX, pointY, fruit.GetRadius(), fruit.GetColor(), -2);
                    _cutBalls.AddRange(firstHalfBall, secondHalfBall);

                    result++;
                    resultLabel.Text = $"Результат: {result}";

                    _fruitBalls.RemoveAt(i);
                }
            }

            for (int i = _bombBalls.Count - 1; i >= 0; i--)
            {
                var bomb = _bombBalls[i];

                if (bomb.IsVisible(pointX, pointY))
                {
                    RestartGame();
                    break;
                }
            }

            for (int i = _bananBalls.Count - 1; i >= 0; i--)
            {
                var banan = _bananBalls[i];

                if (banan.IsVisible(pointX, pointY))
                {
                    SlowDownSpeed();
                    _slowSpeedDownTimer.Start();

                    var firstHalfBall = new CutBall(this, pointX, pointY, banan.GetRadius(), banan.GetColor(), 2);
                    var secondHalfBall = new CutBall(this, pointX, pointY, banan.GetRadius(), banan.GetColor(), -2);
                    _cutBalls.AddRange(firstHalfBall, secondHalfBall);

                    result++;
                    resultLabel.Text = $"Результат: {result}";

                    _bananBalls.RemoveAt(i);
                }
            }
        }

        private void SlowDownSpeed()
        {
            foreach (var fruitBall in _fruitBalls)
            {
                fruitBall.Speed *= 0.5f;
            }
        }

        private void SetStartSpeed()
        {
            foreach (var fruitBall in _fruitBalls)
            {
                fruitBall.Speed = 1.0f;
            }
        }

        private void RestartGame()
        {
            _timer.Stop();
            _spawnTimer.Stop();
            _spawnBombTimer.Stop();
            MessageBox.Show("Вы проиграли!");
            Application.Restart();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            foreach (var fruitBall in _fruitBalls)
            {
                fruitBall.Draw(e.Graphics);
            }

            foreach (var cutBall in _cutBalls)
            {
                cutBall.Draw(e.Graphics);
            }

            foreach (var bombBall in _bombBalls)
            {
                bombBall.Draw(e.Graphics);
            }

            foreach (var bananBall in _bananBalls)
            {
                bananBall.Draw(e.Graphics);
            }
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            _fruitBalls.Clear();
            _cutBalls.Clear();
            _bombBalls.Clear();
            _bananBalls.Clear();

            mistakes = 0;

            result = 0;
            resultLabel.Text = $"Результат: {result}";

            wrongLabel.Text = "Промахи: 0 0 0";

            Invalidate();
        }
    }
}
