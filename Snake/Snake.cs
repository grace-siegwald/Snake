using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using static System.Formats.Asn1.AsnWriter;

namespace Snake
{
    public class Snake : Sprite
    {
        public bool isDead;
        public int Length; //this will change sometimes

        public Snake(Game game) : base(game)
        {
            Direction = new Vector2(game.World.squareSize, 0);
        }
        public override void LoadContent(Game game)
        {
            base.Spawn(game.World, game.World.snakeStartCordinate);
        }
        public void Update(Game game)
        {
            PlayerInput(game);
            Move(game);
            CheckWallCollision(game);
        }
        public override void Draw(Game game) //changed draw to only draw what the logic has determined 
        {
            Raylib.DrawRectangle((int)Location.X, (int)Location.Y, (int)Size.X, (int)Size.Y, Color.SkyBlue);
            if (isDead)
            {
                Raylib.DrawText($"YOU DIED", game.WindowWidth / 3, game.WindowHeight / 3, 40, Raylib_cs.Color.Red); //make new sreen

            }
        }
        public void Grow(Game game)
        {
            Length++;
        }
        public void Eat()
        {
            // TODO: add eating logic here
        }
        public void Move(Game game)
        {
            // Movement should basically be Location = Location + Direction * Speed (I THINK!)
            game.moveTimer += Raylib.GetFrameTime();

            if (game.moveTimer >= game. moveInterval)
            {
                Location.X += Direction.X;
                Location.Y += Direction.Y;
                game.moveTimer -= game.moveInterval; //resets the move timer
            }
        }
        public void PlayerInput(Game game)
        {
            if (Raylib.IsKeyPressed(KeyboardKey.Left) && !(Direction.X > 0))
            {
                // Left
                Direction = new Vector2(-game.World.squareSize, 0);
            }
            if (Raylib.IsKeyPressed(KeyboardKey.Right) && !(Direction.X < 0))
            {
                // Right
                Direction = new Vector2(game.World.squareSize, 0);
            }
            if (Raylib.IsKeyPressed(KeyboardKey.Up) && !(Direction.Y > 0))
            {
                // Up
                Direction = new Vector2(0, -game.World.squareSize);
            }
            if (Raylib.IsKeyPressed(KeyboardKey.Down) && !(Direction.Y < 0))
            {
                // Down
                Direction = new Vector2(0, game.World.squareSize);
            }
        }

        public void CheckWallCollision(Game game)
        {
            if (Location.X < 0 || Location.X >= game.WindowWidth || Location.Y < 0 || Location.Y >= game.WindowHeight)
            {
                isDead = true;
            }
        }
    }
}