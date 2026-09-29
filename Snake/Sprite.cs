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
            Width = game.squareSize;
            Height = game.squareSize;
        }

        public void Spawn(int SpawnX, int SpawnY)
        {
            SpawnLocationX = SpawnX;
            SpawnLocationY = SpawnY;

            //spawn just means draw on the screen at x location

        }
    }
}
