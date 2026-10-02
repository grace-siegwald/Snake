using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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


        //using to randomize spawn location
        public List<int> GameBoardCoordinatesList = new List<int>() {50, 100, 150, 200, 250};
        Random rnd1 = new Random();

        public Sprite(Game game) // pass in an instance of the Game
        {
            Width = game.World.squareSize;
            Height = game.World.squareSize;
        }
        public virtual void RandomSpawn(Game game)
        {
            int RandomCoordinateX = new Random().Next(0, game.World.numVertLines) * game.World.squareSize;  //randomly geenrates a coordinate based on the already established grid syste
            int RandomCoordinateY = new Random().Next(0, game.World.numHorLines) * game.World.squareSize;
            SpawnLocationX = RandomCoordinateX;
            SpawnLocationY = RandomCoordinateY;

        }
        public virtual void Spawn(int SpawnX, int SpawnY)
        {
            // TODO: Normalize the spawn locations so it's just the "grid" coordinate of the world (ie 1,1 is top left square)
            SpawnLocationX = SpawnX;
            SpawnLocationY = SpawnY;

            //spawn just means draw on the screen at x location
        }

        public virtual void Random()
        {//https://www.tutorialsteacher.com/articles/generate-random-numbers-in-csharp


            Random rnd = new Random();
            int num = rnd.Next();
        }

        //int r = rnd.Next(list.Count);

        //public virtual void RandomSpawn()
        //{
        //    int num1 = GameBoardCoordinatesList[rnd1.Next(GameBoardCoordinatesList.Count)];
        //    int num2 = GameBoardCoordinatesList[rnd1.Next(GameBoardCoordinatesList.Count)];

        //    Spawn(num1, num2);
        //    //SpawnLocationX = SpawnX;
        //    //SpawnLocationY = SpawnY;

        //}



        public virtual void Draw()
        {
            Raylib.DrawRectangle(SpawnLocationX, SpawnLocationY, Width, Height, Color.SkyBlue);
        }
    }
}
