using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public override void Draw()
        {
            if (!Eaten) 
            {
                Raylib.DrawRectangle(SpawnLocationX, SpawnLocationY, Width, Height, Color.LightGray);  
            }
            else
            {
                // TODO: draw in a new randomized location?
            }
        }
        public void getEaten() //this is temp and should be in snake 
        {

            if (Raylib.IsKeyPressed(KeyboardKey.Enter)) //replace the condition with the collision between snake and food 
            {
                Eaten = true;
                //TODO: add a point to the score - add score in drawing logic 

            }
        }
    }
}
