using System.Numerics;
using Xunit;

namespace Snake.Tests
{
    // Builds a Game the same way StartGame() does, without opening a Raylib window.
    internal static class TestGame
    {
        public static Game Create()
        {
            var game = new Game();
            game.Snakes.Add(new Snake(game));
            game.Food = new Food(game);
            game.Score = new Score(game);
            game.Snakes[0].Spawn(game.World, game.World.snakeStartCordinate);
            return game;
        }

        // Forces exactly one movement step, no matter how much real time has passed.
        public static void Step(Game game, Snake snake)
        {
            game.moveTimer = game.moveInterval;
            snake.Move(game);
        }
    }

    // ---------- Feature 1: Movement ----------
    public class MovementTests
    {
        [Fact] // Normal use
        public void Snake_MovesOneSquareRight_OnEachStep()
        {
            var game = TestGame.Create();
            var snake = game.Snakes[0];
            var start = snake.Location;

            TestGame.Step(game, snake);

            Assert.Equal(start + new Vector2(40, 0), snake.Location);
        }

        [Fact] // Unexpected input: called before the move interval has passed
        public void Snake_DoesNotMove_BeforeMoveIntervalHasPassed()
        {
            var game = TestGame.Create();
            var snake = game.Snakes[0];
            var start = snake.Location;

            game.moveTimer = 0f;
            snake.Move(game);

            Assert.Equal(start, snake.Location);
        }

        [Fact] // Edge case: body length never exceeds Length
        public void Body_NeverHasMoreSegmentsThanLength()
        {
            var game = TestGame.Create();
            var snake = game.Snakes[0];
            snake.Length = 3;

            for (int i = 0; i < 6; i++) TestGame.Step(game, snake);

            Assert.Equal(3, snake.Body.Count);
        }
    }

    // ---------- Feature 2: Eating food, growing and scoring ----------
    public class EatingTests
    {
        [Fact] // Normal use
        public void EatingFood_AddsPoint_AndGrowsSnake()
        {
            var game = TestGame.Create();
            var snake = game.Snakes[0];
            game.Food.Location = snake.Location;

            game.Food.Update(game);

            Assert.Equal(1, game.Score.score);
            Assert.Equal(1, snake.Length);
        }

        [Fact] // Unexpected input: food is next to the head, not under it
        public void FoodNextToHead_IsNotEaten()
        {
            var game = TestGame.Create();
            var snake = game.Snakes[0];
            game.Food.Location = snake.Location + new Vector2(40, 0);

            game.Food.Update(game);

            Assert.Equal(0, game.Score.score);
            Assert.Equal(0, snake.Length);
        }

        [Fact] // Edge case: growth appears as exactly one new segment after the next step
        public void AfterEating_BodyGrowsByOneSegment()
        {
            var game = TestGame.Create();
            var snake = game.Snakes[0];
            game.Food.Location = snake.Location;

            game.Food.Update(game);
            TestGame.Step(game, snake);
            TestGame.Step(game, snake);

            Assert.Single(snake.Body);
        }
    }

    // ---------- Feature 3: Collision / game over ----------
    public class CollisionTests
    {
        [Fact] // Normal use
        public void SnakeInsideGrid_IsAlive()
        {
            var game = TestGame.Create();
            var snake = game.Snakes[0];

            TestGame.Step(game, snake);
            snake.CheckCollision(game);

            Assert.False(snake.isDead);
        }

        [Theory] // Boundary: last square on each edge is safe, one step further is death
        [InlineData(760, 280, 40, 0, false, true)]   // right edge
        [InlineData(0, 280, -40, 0, false, true)]    // left edge
        [InlineData(280, 0, 0, -40, false, true)]    // top edge
        [InlineData(280, 560, 0, 40, false, true)]   // bottom edge
        public void Walls_LastSquareIsSafe_NextSquareKills(
            float x, float y, float dx, float dy, bool deadBefore, bool deadAfter)
        {
            var game = TestGame.Create();
            var snake = game.Snakes[0];
            snake.Location = new Vector2(x, y);
            snake.Direction = new Vector2(dx, dy);

            snake.CheckCollision(game);
            Assert.Equal(deadBefore, snake.isDead);

            TestGame.Step(game, snake);
            snake.CheckCollision(game);
            Assert.Equal(deadAfter, snake.isDead);
        }

        [Fact] // Invalid move: head runs into its own body
        public void HeadHittingBody_KillsSnake()
        {
            var game = TestGame.Create();
            var snake = game.Snakes[0];
            snake.Location = new Vector2(80, 80);
            snake.Length = 4;
            snake.Body.AddRange(new[] {
                new Vector2(80, 120), new Vector2(120, 120),
                new Vector2(120, 80), new Vector2(120, 40) });
            snake.Direction = new Vector2(40, 0); // turn right into (120, 80)

            TestGame.Step(game, snake);
            snake.CheckCollision(game);

            Assert.True(snake.isDead);
        }

        [Fact] // Edge case: moving into the square the tail is leaving is allowed
        public void MovingIntoVacatedTailSquare_IsNotDeath()
        {
            var game = TestGame.Create();
            var snake = game.Snakes[0];
            snake.Location = new Vector2(0, 0);
            snake.Length = 3;
            snake.Body.AddRange(new[] {
                new Vector2(40, 0), new Vector2(40, 40), new Vector2(0, 40) });
            snake.Direction = new Vector2(0, 40); // down, into the tail's square

            TestGame.Step(game, snake);
            snake.CheckCollision(game);

            Assert.False(snake.isDead);
        }
    }
}
