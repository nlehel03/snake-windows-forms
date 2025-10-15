using NUnit.Framework;
using snake_windows_forms.Models;
using System.Drawing;

namespace SnakeTest
{
    public class Tests
    {
        private static void SetSnake(GameState gs, params Point[] body)
        {
            gs.snake.body.Clear();
            gs.snake.body.AddRange(body);
        }

        [Test]
        public void GameState_InitializesSnakeAtCenter()
        {
            var n = 20;
            var gs = new GameState(n);

            Assert.That(gs.snake.body[0], Is.EqualTo(new Point(n / 2, n / 2)));
            Assert.That(gs.isGameOver, Is.False);
            Assert.That(gs.score, Is.EqualTo(0));
        }

        [Test]
        public void InitialSnakeLength_IsFive()
        {
            var gs = new GameState(20);
            Assert.That(gs.snake.body.Count, Is.EqualTo(5));
        }

        [Test]
        public void Update_MovesSnakeOneStepWithoutGrowing()
        {
            var gs = new GameState(20);
            SetSnake(gs, new Point(5, 5));
            gs.SetDirection(Direction.Right);

            gs.Update();

            Assert.That(gs.snake.body[0], Is.EqualTo(new Point(6, 5)));
            Assert.That(gs.snake.body.Count, Is.EqualTo(1)); 
            Assert.That(gs.isGameOver, Is.False);
        }

        [Test]
        public void Move_DoesNotChangeLength_WhenNoFood_LongSnake()
        {
            var gs = new GameState(20);
            SetSnake(gs, new Point(3, 3), new Point(2, 3), new Point(1, 3));
            gs.SetDirection(Direction.Right);

            int beforeLen = gs.snake.body.Count;
            gs.Update();

            Assert.That(gs.snake.body.Count, Is.EqualTo(beforeLen));
        }

        [Test]
        public void Update_EatFood_IncreasesScoreAndGrows()
        {
            var gs = new GameState(20);
            var food = gs.food.position;
            
            SetSnake(gs, new Point(food.X, food.Y));

            // Biztonságos irány, hogy ne menjen azonnal falnak
            if (food.X < gs.n - 1) gs.SetDirection(Direction.Right);
            else if (food.X > 0) gs.SetDirection(Direction.Left);
            else if (food.Y < gs.n - 1) gs.SetDirection(Direction.Down);
            else gs.SetDirection(Direction.Up);

            int beforeLen = gs.snake.body.Count;
            int beforeScore = gs.score;

            gs.Update();

            Assert.That(gs.score, Is.EqualTo(beforeScore + 1), "Pontszámnak nõnie kell étel evéskor.");
            Assert.That(gs.snake.body.Count, Is.EqualTo(beforeLen + 1), "Kígyónak nõnie kell étel evéskor.");
            Assert.That(gs.snake.body.Contains(gs.food.position), Is.False, "Új étel nem lehet a kígyó testén.");
        }

        [TestCase(0, 5, Direction.Left)]
        [TestCase(9, 5, Direction.Right)]
        [TestCase(5, 0, Direction.Up)]
        [TestCase(5, 9, Direction.Down)]

        public void Update_WallCollision_SetsGameOver_AllEdges(int x, int y, Direction d)
        {
            var gs = new GameState(10);
            SetSnake(gs, new Point(x, y));
            gs.SetDirection(d);

            gs.Update();

            Assert.That(gs.isGameOver, Is.True);
        }

        [Test]
        public void Update_SelfCollision_SetsGameOver()
        {
            var gs = new GameState(10);
            SetSnake(gs,
                new Point(2, 2),
                new Point(2, 1),
                new Point(2, 0),
                new Point(1, 0) 
            );
            gs.SetDirection(Direction.Up);

            gs.Update();

            Assert.That(gs.isGameOver, Is.True);
        }

        [Test]
        public void Food_Respawn_NotOnSnake_AndInsideBounds()
        {
            var gs = new GameState(10);
            SetSnake(gs, new Point(1, 1), new Point(2, 1), new Point(3, 1), new Point(3, 2), new Point(3, 3));

            for (int i = 0; i < 50; i++)
            {
                gs.food.Respawn(gs.n, gs.snake.body);
                var p = gs.food.position;
                Assert.Multiple(() =>
                {
                    Assert.That(gs.snake.body.Contains(p), Is.False, "Respawn nem teheti a kaját a kígyóra.");
                    Assert.That(p.X, Is.InRange(0, gs.n - 1));
                    Assert.That(p.Y, Is.InRange(0, gs.n - 1));
                });
            }
        }

        [Test]
        public void Update_DoesNothing_WhenGameOver()
        {
            var gs = new GameState(5);
            SetSnake(gs, new Point(0, 0));
            gs.SetDirection(Direction.Left);
            gs.Update();

            var scoreAfterGo = gs.score;
            var headAfterGo = gs.snake.body[0];

            gs.Update();

            Assert.Multiple(() =>
            {
                Assert.That(gs.score, Is.EqualTo(scoreAfterGo));
                Assert.That(gs.snake.body[0], Is.EqualTo(headAfterGo));
                Assert.That(gs.isGameOver, Is.True);
            });
        }

        [Test]
        public void SetDirection_ChangesDirection()
        {
            var gs = new GameState(10);
            gs.SetDirection(Direction.Right);
            Assert.That(gs.snake.direction, Is.EqualTo(Direction.Right));
        }
    }
}