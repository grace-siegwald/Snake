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
    public class Food : Sprite
    {
        public int Value; //this is the players points

        public bool Eaten = false;
        public Food(Game game) : base(game) // Pass the required Game instance to the base Sprite constructor
        { 
        
        }
        public override void LoadContent(Game game)
        {
            RandomSpawn(game.World);
        }
        public void Update(Game game)
        {
            getEaten(game);
        }
        public override void Draw() //changed draw to only draw what the logic has determined 
        {
            Raylib.DrawRectangle((int)Location.X, (int)Location.Y, Width, Height, Color.LightGray);  
        }

        public void RandomSpawn(World world)
        {
            int RandomCoordinateX = new Random().Next(0, world.numVertLines) * world.squareSize;  //randomly generates a coordinate based on the already established grid system
            int RandomCoordinateY = new Random().Next(0, world.numHorLines) * world.squareSize;
            Location = new Vector2(RandomCoordinateX, RandomCoordinateY);
        }

        public void getEaten(Game game) //this is temp and should be in snake - this now handles the logi of if the food has been eaten or not 
        {

            if (Raylib.IsKeyPressed(KeyboardKey.Enter)) //replace the condition with the collision between snake and food 
            {
                Eaten = true;
                //TODO: add a point to the score - add score in drawing logic 
                RandomSpawn(game.World);
                Eaten = false; //reset the eaten state for the next food spawn
            }
        }
    }
}
