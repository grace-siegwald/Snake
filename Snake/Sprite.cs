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
        public Vector2 Size;
        public Vector2 Direction;
        // These two fields change during gameplay:
        public Vector2 Location; //this will change consistently
        public int Length; //this will change sometimes


        public Sprite(Game game) // pass in an instance of the Game
        {
            int width = game.World.squareSize;
            int height = game.World.squareSize;
            Size = new Vector2 (width, height);
        }
       
        public virtual void LoadContent(Game game)
        {
            RandomSpawn(game.World);
        }

        public void RandomSpawn(World world)
        {
            int RandomCoordinateX = new Random().Next(0, world.numVertLines) * world.squareSize;  //randomly generates a coordinate based on the already established grid system
            int RandomCoordinateY = new Random().Next(0, world.numHorLines) * world.squareSize;
            Location = new Vector2(RandomCoordinateX, RandomCoordinateY);
        }

        public virtual void Draw()
        {
            Raylib.DrawRectangle((int)Location.X, (int)Location.Y, (int)Size.X, (int)Size.Y, Color.SkyBlue);
        }
    }
}
