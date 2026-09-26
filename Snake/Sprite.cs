using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Sprite 
    {
        public int SpawnLocation; //this only occurs once at the start of the game
        public int Direction;
        public int Speed;
        public int Location; //this will change consistently
        public int Length; //this will change sometimes
        public Sprite() 
        { }


    }
}
