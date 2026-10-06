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
    public class Sprite 
    {
        public int Width;
        public int Height;
        public int SpawnLocationX;
        public int SpawnLocationY; //sprite position is being controlled here
        public int SpawnLocationY1; //this only occurs once at the start of the game
        public Vector2 Direction;
        public int Speed;
        // These two fields change during gameplay:
        public Vector2 Location; //this will change consistently
        public int Length; //this will change sometimes


        public Sprite(Game game) // pass in an instance of the Game
        {
            Width = game.World.squareSize;
            Height = game.World.squareSize;
        }
       
        public virtual void LoadContent(Game game)
        {
            Spawn(1, 1, game);
        }

        public virtual void Spawn(int SpawnX, int SpawnY, Game game)
        {
            // TODO: Normalize the spawn locations so it's just the "grid" coordinate of the world (ie 1,1 is top left square)
            SpawnLocationX = SpawnX * game.World.squareSize;
            SpawnLocationY = SpawnY * game.World.squareSize;

            //spawn just means draw on the screen at x location
        }

        public virtual void Draw()
        {
            Raylib.DrawRectangle((int)Location.X, (int)Location.Y, Width, Height, Color.SkyBlue);
        }
    }
}
