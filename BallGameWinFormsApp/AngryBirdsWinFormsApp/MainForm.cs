using Timer = System.Windows.Forms.Timer;

namespace AngryBirdsWinFormsApp
{
    public partial class MainForm : Form
    {
        private readonly List<Bird> _birds = [];
        private readonly List<Pig> _pigs = [];
        private readonly Timer _timer = new();
        private int result = 0;
        private bool isHit = false;
        private bool isStopped = true;
        private bool isCountedScore = false;

        public MainForm()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();

            _timer.Interval = 10;

            _timer.Tick += (s, e) =>
            {
                foreach (var bird in _birds)
                {
                    if (!bird.IsStopped)
                    {
                        isStopped = false;

                        bird.Move();

                        if (bird.IsHit)
                        {
                            isHit = true;
                        }
                    }

                    if (bird.IsStopped)
                    {
                        isStopped = true;
                    }
                }

                Invalidate();

                if (isHit && !isCountedScore)
                {
                    HitPig();
                    isCountedScore = true;
                }

                if (isStopped)
                {
                    ShowNextLevel();
                }
            };
        }

        private void ShowNextLevel()
        {
            _birds.Clear();
            _pigs.Clear();

            isCountedScore = false;
            isHit = false;
            isStopped = true;

            CreateAnimals();
        }

        private void HitPig()
        {
            foreach (var bird in _birds)
            {
                _pigs.Remove(bird.Pig);
            }

            result++;
            resultLabel.Text = $"Результат: {result}";
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            foreach (var bird in _birds)
            {
                bird.Draw(e.Graphics);
            }

            foreach (var pig in _pigs)
            {
                pig.Draw(e.Graphics);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CreateAnimals();
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (var bird in _birds)
            {
                if (!bird.IsStopped)
                {
                    bird.SetSpeed(e.X, e.Y);
                    _timer.Start();
                }
            }
        }

        private void CreateAnimals()
        {
            var pig = new Pig(this);
            _pigs.Add(pig);

            var bird = new Bird(this, pig, _timer);
            _birds.Add(bird);
        }
    }
}
