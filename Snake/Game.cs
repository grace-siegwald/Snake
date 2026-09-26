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


        public void updateLogic()
        {

        }


        public void Draw()
        {
            // Initialize a window with a width, height, and title
            Raylib.InitWindow(800, 480, "Hello Raylib C#");
            Raylib.SetTargetFPS(60);

            // Main game loop
            while (!Raylib.WindowShouldClose())
            {
                // 1. Update logic goes here (e.g., checking input)

                // 2. Drawing logic
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.RayWhite);

                Raylib.DrawText("Congrats! You created your first Raylib C# window!", 100, 200, 20, Color.LightGray);

                Raylib.EndDrawing();
            }

            // Close the window and clear resources
            Raylib.CloseWindow();

        }


    }
}
