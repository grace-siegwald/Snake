using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace Snake
{
    public class Game
    {
        Food food = new Food();

        //use flags to change drawing states
        bool Eaten = false;
        public void updateLogic()
        {
            //check sprite spawn
            food.Spawn(100, 100);
            food.eat();

            if (Raylib.IsKeyPressed(KeyboardKey.Enter)) //replace the condition with the collision between snake and food 
            {
                Eaten = true; 
            }

        }


        public void Draw()
        {

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);


            if (Eaten == false)
            {
                Raylib.DrawRectangle(food.SpawnLocationX, food.SpawnLocationY, food.Width, food.Height, Color.Blue); //can you change these paramters to be the ones in sprite 
            }



            Raylib.EndDrawing();

        }



    }
}
