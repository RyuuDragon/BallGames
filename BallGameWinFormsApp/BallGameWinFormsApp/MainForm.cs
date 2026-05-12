using BallGames.Common;

namespace BallGameWinFormsApp
{
    public partial class MainForm : Form
    {
        private List<RandomMoveBall> randomMoveBalls = [];
        private int result = 0;
        private bool pressStop = false;
        private Point lastPoint;

        public MainForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            ClearForm();

            for (var i = 0; i < 10; i++)
            {
                var randomMoveBall = new RandomMoveBall(this);
                randomMoveBalls.Add(randomMoveBall);
                randomMoveBall.Start();
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (!pressStop)
            {
                for (var i = 0; i < randomMoveBalls.Count; i++)
                {
                    randomMoveBalls[i].Stop();
                }

                result = GetResult();
                resultLabel.Text = $"Результат: {result}";

                pressStop = true;
            }
        }

        private void ClearForm()
        {
            for (var i = 0; i < randomMoveBalls.Count; i++)
            {
                randomMoveBalls[i].Stop();
            }

            result = 0;
            resultLabel.Text = $"Результат: {result}"; ;

            pressStop = false;

            randomMoveBalls.Clear();
            Invalidate();
        }

        private int GetResult()
        {
            for (var i = 0; i < randomMoveBalls.Count; i++)
            {
                if (randomMoveBalls[i].OnForm())
                {
                    result++;
                }
            }

            return result;
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
