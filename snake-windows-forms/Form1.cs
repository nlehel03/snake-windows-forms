using snake_windows_forms.Models;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;


namespace snake_windows_forms
{
    public partial class Form1 : Form
    {
        private GameState model;
        private const int CellSize = 20;
        public Form1()
        {
            InitializeComponent();
            model = new GameState(25);
            this.ClientSize = new Size(model.n * CellSize, model.n * CellSize);
            this.DoubleBuffered = true;
            this.KeyDown += Form1_KeyDown;
            timer1.Start();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up: model.snake.direction = Direction.Up; break;
                case Keys.Down: model.snake.direction = Direction.Down; break;
                case Keys.Left: model.snake.direction = Direction.Left; break;
                case Keys.Right: model.snake.direction = Direction.Right; break;
            }
        }


        private void scoresLabel_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            model.Update();
            timer1.Interval = 100; // 100 ms
            this.Invalidate();
            if (model.isGameOver)
            {
                timer1.Stop();
                Console.WriteLine("Game Over! Your score: " + model.score);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
             base.OnPaint(e);
            foreach(var segment in model.snake.body)
            {
                e.Graphics.FillRectangle(Brushes.Green, segment.X * CellSize, segment.Y * CellSize , CellSize, CellSize);
            }
            //keret
            e.Graphics.DrawRectangle(Pens.Green, 0, 0, (model.n * CellSize - 1), (model.n * CellSize - 1));
            // Food kirajzolása
            var f = model.food.position;
            e.Graphics.FillRectangle(Brushes.Red, f.X * CellSize, f.Y * CellSize, CellSize, CellSize);
            Debug.WriteLine($"Food at {f}");

            // Pontszám
            using (var scoreFont = new Font("Courier New", 14.25f, FontStyle.Bold))
            {
                e.Graphics.DrawString("Score: " + model.score,
                                      scoreFont, Brushes.Green, 10, 10);
            }

            // Game Over
            if (model.isGameOver)
            {
                string msg = "GAME OVER";
                var font = new Font("Arial", 24, FontStyle.Bold);
                var size = e.Graphics.MeasureString(msg, font);
                e.Graphics.DrawString(msg, font, Brushes.White,
                                      ClientSize.Width - size.Width,
                                      ClientSize.Height - size.Height);
            }

        }
    }
}
