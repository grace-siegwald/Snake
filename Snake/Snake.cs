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
        public List<Vector2> Body = new List<Vector2>(); // Basically a list of "locations" for the body of the snake, they get drawn in the draw method

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
            foreach (Vector2 segment in Body)
            {
                Raylib.DrawRectangle((int)segment.X, (int)segment.Y, (int)Size.X, (int)Size.Y, Color.Blue);
            }
            if (isDead)
            {
                Raylib.DrawText($"YOU DIED", game.WindowWidth / 3, game.WindowHeight / 3, 40, Raylib_cs.Color.Red); //make new sreen

            }
        }
        public void Grow(Game game)
        {
            Length++;
        }
        public void Move(Game game)
        {
            // getting the number of seconds that have passed since the last frame and adding it to the move timer
            game.moveTimer += Raylib.GetFrameTime();

            // if the move timer is greater than or equal to the move interval, then we move the snake, this is what gives the snake a consistent speed regardless of the frame rate
            if (game.moveTimer >= game. moveInterval)
            {
                Body.Insert(0, Location); // adds the current location of the snake to the front of the body list, this is what makes the body follow the head
                
                // moves the snake in the direction it's currencly facing
                Location.X += Direction.X;
                Location.Y += Direction.Y;

                // if the body list is longer than the length of the snake, then we remove the last segment of the body list, this is what makes the body follow the head
                // basically, we're contstantly removing the last bit of the body list and adding a new bit to the front of the list, creating the "body follows head" effect
                if (Body.Count > Length)
                {
                    Body.RemoveAt(Body.Count - 1);
                }

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