using snake_windows_forms.Models;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace snake_windows_forms.View
{
    public partial class GameView : Form
    {
        private GameState model;
        private int CellSize;
        private bool isPaused = false;

        public GameView(int c, int n)
        {
            InitializeComponent();
            CellSize = c;
            model = new GameState(n);
            this.ClientSize = new Size(model.n * CellSize, model.n * CellSize);
            this.DoubleBuffered = true;
            this.KeyDown += Form1_KeyDown;
            timer1.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:    model.SetDirection(Direction.Up); break;
                case Keys.Down:  model.SetDirection(Direction.Down); break;
                case Keys.Left:  model.SetDirection(Direction.Left); break;
                case Keys.Right: model.SetDirection(Direction.Right); break;
                case Keys.P:
                case Keys.Escape:
                    isPaused = !isPaused;
                    if (isPaused) timer1.Stop(); else timer1.Start();
                    this.Invalidate();
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            model.Update();
            timer1.Interval = 100;
            this.Invalidate();

            if (model.isGameOver)
            {
                timer1.Stop();
                this.Hide();
                using (var go = new GameOverView(model.score))
                {
                    go.StartPosition = FormStartPosition.Manual;
                    go.Location = this.Location;
                    go.Size = this.Size;
                    go.ShowDialog(this);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            foreach (var segment in model.SnakeSegments)
            {
                e.Graphics.FillRectangle(Brushes.Green, segment.X * CellSize, segment.Y * CellSize, CellSize, CellSize);
            }

            e.Graphics.DrawRectangle(Pens.Green, 0, 0, (model.n * CellSize - 1), (model.n * CellSize - 1));

            var f = model.food.position;
            e.Graphics.FillRectangle(Brushes.Red, f.X * CellSize, f.Y * CellSize, CellSize, CellSize);
            Debug.WriteLine($"Food at {f}");

            using (var scoreFont = new Font("Courier New", 14.25f, FontStyle.Bold))
            {
                e.Graphics.DrawString("Score: " + model.score, scoreFont, Brushes.Green, 10, 10);
            }

            if (isPaused)
            {
                string pauseMsg = "PAUSED";
                using var font = new Font("Courier New", 24, FontStyle.Bold);
                var size = e.Graphics.MeasureString(pauseMsg, font);

                int pauseWidth = (int)size.Width + 60;
                int pauseHeight = (int)size.Height + 40;
                int pauseX = (ClientSize.Width - pauseWidth) / 2;
                int pauseY = (ClientSize.Height - pauseHeight) / 2;

                e.Graphics.FillRectangle(Brushes.Black, pauseX, pauseY, pauseWidth, pauseHeight);
                using var pen = new Pen(Color.Green, 2f);
                e.Graphics.DrawRectangle(pen, pauseX, pauseY, pauseWidth, pauseHeight);
                e.Graphics.DrawString(pauseMsg, font, Brushes.Green,
                    pauseX + (pauseWidth - size.Width) / 2,
                    pauseY + (pauseHeight - size.Height) / 2);
            }
        }
    }
}
