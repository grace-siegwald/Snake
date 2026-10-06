using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Raylib_cs;

namespace Snake
{
    public class Snake : Sprite
    {
        private float moveTimer = 0f; // number of seconds since the last steps
        private float moveInterval = .1f; // number of seconds between steps
        public Snake(Game game) : base(game)
        {
            Direction = new Vector2(game.World.squareSize, 0);
        } 
        public void Update(Game game)
        {
            PlayerInput(game);
            Move(game);
        }
        public override void Draw() //changed draw to only draw what the logic has determined 
        {
            Raylib.DrawRectangle((int)Location.X, (int)Location.Y, (int)Size.X, (int)Size.Y, Color.SkyBlue);
        }
        public void Eat()
        {
            // TODO: add eating logic here
        }
        public void Move(Game game)
        {
            // Movement should basically be Location = Location + Direction * Speed (I THINK!)
            moveTimer += Raylib.GetFrameTime();
            
            if (moveTimer >= moveInterval)
            {
                Location.X += Direction.X;
                Location.Y += Direction.Y;
                moveTimer -= moveInterval; //resets the move timer
            }
        }
        public void Grow()
        {
            // TODO: add growing logic here
            // If this snake has just ate food, grow by one square size 
        }
        public void PlayerInput(Game game)
        {
            if (Raylib.IsKeyPressed(KeyboardKey.Left))
            {
                // Left
                Direction = new Vector2(-game.World.squareSize, 0);
            }
            if (Raylib.IsKeyPressed(KeyboardKey.Right))
            {
                // Right
                Direction = new Vector2(game.World.squareSize, 0);
            }
            if (Raylib.IsKeyPressed(KeyboardKey.Up))
            {
                // Up
                Direction = new Vector2(0, -game.World.squareSize);
            }
            if (Raylib.IsKeyPressed(KeyboardKey.Down))
            {
                // Down
                Direction = new Vector2(0, game.World.squareSize);
            }
        }
    }
}