using snake_windows_forms.Models;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;


namespace snake_windows_forms
{
    public partial class Form1 : Form
    {
        private GameState model;
        private const int CellSize = 20;
        private bool isPaused = false;
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
                case Keys.P or Keys.Escape:
                    isPaused = !isPaused;
                    if (isPaused)
                    {
                        timer1.Stop();
                    }
                    else
                    {
                        timer1.Start();
                    }
                    this.Invalidate(); 
                    break;
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
                string gameOverMsg = "GAME OVER";
                string scoreMsg = $"Final Score: {model.score}";

                var scoreFont = new Font("Courier New", 18, FontStyle.Bold);
                var gameOverFont = new Font("Courier New", 24, FontStyle.Bold);

                var gameOverSize = e.Graphics.MeasureString(gameOverMsg, gameOverFont);
                var scoreSize = e.Graphics.MeasureString(scoreMsg, scoreFont);

                float gameOverX = (ClientSize.Width - gameOverSize.Width) / 2;
                float gameOverY = (ClientSize.Height - gameOverSize.Height) / 2;

                float scoreX = (ClientSize.Width - scoreSize.Width) / 2;
                float scoreY = gameOverY + gameOverSize.Height + 10; 

                e.Graphics.DrawString(gameOverMsg, gameOverFont, Brushes.Green, gameOverX, gameOverY);
                e.Graphics.DrawString(scoreMsg, scoreFont, Brushes.Green, scoreX, scoreY);
            
            }
            //Pause
            if(isPaused)
            {
                string pauseMsg = "PAUSED";
                var font = new Font("Courier New", 24, FontStyle.Bold);
                var size = e.Graphics.MeasureString(pauseMsg, font);

                int menuWidth = (int)size.Width + 60;
                int menuHeight = (int)size.Height + 40;
                int menuX = (ClientSize.Width - menuWidth) / 2;
                int menuY = (ClientSize.Height - menuHeight) / 2;

                e.Graphics.FillRectangle(Brushes.Black, menuX, menuY, menuWidth, menuHeight);
                e.Graphics.DrawRectangle(Pens.Green, menuX, menuY, menuWidth, menuHeight);

                e.Graphics.DrawString(pauseMsg, font, Brushes.Green, menuX + (menuWidth - size.Width) / 2, menuY + (menuHeight - size.Height) / 2);
            }

        }
    }
}
