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
        private int snakeLengh;

        public Snake(Game game) : base(game)
        {
            Direction = new Vector2(game.World.squareSize, 0);
        } 
        public void Update(Game game)
        {
            Move(game);
            PlayerInput();
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
            Location.X += Direction.X;
            Location.Y += Direction.Y;
        }
        public void Grow()
        {
            // TODO: add growing logic here
            // If this snake has just ate food, grow by one square size 
        }
        public void PlayerInput()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.Left))
            {
                // Change snake direction to Left (-world.squareSize, 0)
            }
            if (Raylib.IsKeyPressed(KeyboardKey.Right))
            {
                // Change snake direction to Right (world.squareSize, 0)
            }
            if (Raylib.IsKeyPressed(KeyboardKey.Up))
            {
                // Change snake direction to Up (0, -world.squareSize)
            }
            if (Raylib.IsKeyPressed(KeyboardKey.Down))
            {
                // Change snake direction to Down (0, world.squareSize)
            }
        }
    }
}