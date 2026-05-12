using BallGames.Common;

namespace BallGameWinFormsApp
{
    public partial class MainForm : Form
    {
        private List<RandomMoveBall> randomMoveBalls = [];
        private int result = 0;
        private static Random random = new();
        private Point lastPoint;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var rule = "При нажатии кнопки старт появится от 5 до 25 шариков. " +
                "Ваша задача поймать как можно больше шариков нажатием мышки. " +
                "Считаются только шарики которые находятся полностью на поле!!! " +
                "Очистить форму и остановить игру можно нажатием кнопки ОЧИСТИТЬ " +
                "Если хотите начать заново нажмите кнопку СТАРТ";

            MessageBox.Show(rule);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            ClearForm();

            var ballsCount = random.Next(5, 25);
            for (var i = 0; i < ballsCount; i++)
            {
                var randomMoveBall = new RandomMoveBall(this);
                randomMoveBalls.Add(randomMoveBall);
                randomMoveBall.Start();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            for (var i = 0; i < randomMoveBalls.Count; i++)
            {
                randomMoveBalls[i].Stop();
            }

            result = 0;
            resultLabel.Text = $"Результат: {result}";

            randomMoveBalls.Clear();
            Invalidate();
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (var randomMoveBall in randomMoveBalls)
            {
                if (randomMoveBall.IsVisible(e.X, e.Y) && randomMoveBall.OnForm() && randomMoveBall.IsNotStop())
                {
                    randomMoveBall.Stop();

                    result++;
                    resultLabel.Text = $"Результат: {result}";
                }
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