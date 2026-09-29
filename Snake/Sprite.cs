using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public int Direction;
        public int Speed;
        // These two fields change during gameplay:
        public int Location; //this will change consistently
        public int Length; //this will change sometimes
        public Sprite(Game game) // pass in an instance of the Game
        {
            Width = game.World.squareSize;
            Height = game.World.squareSize;
        }

        public virtual void Spawn(int SpawnX, int SpawnY)
        {
            // TODO: Normalize the spawn locations so it's just the "grid" coordinate of the world (ie 1,1 is top left square)
            SpawnLocationX = SpawnX;
            SpawnLocationY = SpawnY;

            //spawn just means draw on the screen at x location
        }
        public virtual void Draw()
        {
            Raylib.DrawRectangle(SpawnLocationX, SpawnLocationY, Width, Height, Color.SkyBlue);
        }
    }
}
