using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace snake_windows_forms.Models
{
    public class GameState
    {
        public int n { get; }
        public Snake snake { get; }
        public Food food { get; private set; }
        public int score { get; private set; }
        public bool isGameOver { get; private set; }
        Random r = new Random();

        public GameState(int n)
        {
            this.n = n;
            Point startPosition = new Point(n / 2, n / 2);
            snake = new Snake(startPosition);
            food = new Food(new Point(r.Next(0, n), r.Next(0, n)));
            score = 0;
            isGameOver = false;
        }

        public void Update()
        {
            if (isGameOver) return;
            bool grow = snake.body[0].Equals(food.position);
            snake.Move(grow);
            if (grow)
            {
                score++;
                food.Respawn(n, snake.body);
            }
            if (snake.IsCollisionWithSelf() || IsCollisionWithWall())
            {
                isGameOver = true;
            }
        }

        private bool IsCollisionWithWall()
        {
            Point head = snake.body[0];
            return head.X < 0 || head.X >= n || head.Y < 0 || head.Y >= n;
        }


    }

}
