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
        public int SpawnLocationX;
        public int Width =49; //these are working - 49 so it fits in the 50x50 squares of the grid
        public int Height = 49;
        public int SpawnLocationY; //sprite position is being controlled here
        public int SpawnLocationY1;//this only occurs once at the start of the game
        public int Direction;
        public int Speed;
        public int Location; //this will change consistently
        public int Length; //this will change sometimes
        public Sprite() 
        {
        }

        public void Spawn(int SpawnX, int SpawnY)
        {
            SpawnLocationX = SpawnX;
            SpawnLocationY = SpawnY;

            //spawn just means draw on the screen at x location

        }
    }
}
