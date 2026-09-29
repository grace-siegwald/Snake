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
        public Food()
        { }

        public void getEaten() //this is temp and should be in snake 
        {

            if (Raylib.IsKeyPressed(KeyboardKey.Enter)) //replace the condition with the collision between snake and food 
            {
                Eaten = true;
                //add a point to the score - add score in drawing logic 

            }
        }
    }
}
